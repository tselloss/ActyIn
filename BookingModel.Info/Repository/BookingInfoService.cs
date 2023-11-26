using BookingModel.Info.Interface;
using Define.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace BookingModel.Info.Repository
{
    public class BookingInfoService : ControllerBase, IBookingInfo
    {

        private readonly NpgsqlContext _context;

        public BookingInfoService(NpgsqlContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void CancelBooking(BookingEntity athletesEntity)
        {
            var result = _context.Bookings.FirstOrDefault(x => x.BookingId == athletesEntity.BookingId);
            if (result.IsCanceled == false)
            {
                athletesEntity.IsCanceled = true;
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<BookingEntity>> GetAllBookingsAsync()
        {
            return await _context.Bookings.Where(b => !b.IsCanceled).OrderBy(_ => _.BookingId).ToListAsync();
        }

        public async Task<BookingEntity> GetBookingOfAthletesInfoByIdAsync(int bookingId)
        {
            return await _context.Bookings.Where(b => !b.IsCanceled).Where(_ => _.BookingId == bookingId).FirstOrDefaultAsync();
        }

        public IActionResult CreateABooking(BookingEntity bookingEntity)
        {
            if (bookingEntity == null)
            {
                return BadRequest(string.Format("Booking is null"));
            }

            _context.Bookings.Add(bookingEntity);
            _context.SaveChanges();

            return Ok(AthletesMessages.CompletedRequest);
        }

        public async Task<bool> SaveChangesAsync(string message)
        {
            try
            {
                return await _context.SaveChangesAsync() >= 0;
            }
            catch (ControllerExceptionMessage)
            {
                throw new ControllerExceptionMessage(message);
            }
        }
    }
}
