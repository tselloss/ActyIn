using BookingModel.Info.Interface;
using Define.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace BookingModel.Info.Repository;
public class BookingInfoService : ControllerBase, IBookingInfo
{

    private readonly NpgsqlContext _context;
    private readonly ILogger<BookingInfoService> _logger;


    public BookingInfoService(NpgsqlContext context, ILogger logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = (ILogger<BookingInfoService>)(logger ?? throw new ArgumentException(nameof(logger)));
    }

    public void CancelBooking(BookingEntity athletesEntity)
    {        
        try
        {
            var result = _context.Bookings.FirstOrDefault(x => x.BookingId == athletesEntity.BookingId);
            if (result.IsCanceled == false)
            {
                athletesEntity.IsCanceled = true;
                _context.SaveChanges();
                _logger.LogInformation(BookingServiceMessages.CancelExceptionSuccess);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, BookingServiceMessages.CancelExceptionError);
            throw;
        }
    }

    public async Task<IEnumerable<BookingEntity>> GetAllBookingsAsync()
    {        
        try
        {
            var getAll = await _context.Bookings.Where(b => !b.IsCanceled).OrderBy(_ => _.BookingId).ToListAsync();
            _logger.LogInformation(BookingServiceMessages.GetAllExceptionSuccess);

            return getAll;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, BookingServiceMessages.GetAllExceptionError);
            throw;
        }
    }

    public async Task<BookingEntity> GetBookingOfAthletesInfoByIdAsync(int bookingId)
    {
        try
        {
            var getById = await _context.Bookings.Where(b => !b.IsCanceled).Where(_ => _.BookingId == bookingId).FirstOrDefaultAsync();
            _logger.LogInformation(BookingServiceMessages.GetByIdExceptionSuccess);
            return getById;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, BookingServiceMessages.GetByIdExceptionError);
            throw;
        }
    }

    public IActionResult CreateABooking(BookingEntity bookingEntity)
    {
        try
        {
            if (bookingEntity == null)
            {
                return BadRequest(string.Format(BookingServiceMessages.EmptyModel));
            }

            _context.Bookings.Add(bookingEntity);
            _context.SaveChanges();
            _logger.LogInformation(BookingServiceMessages.CreateBookingSucceed);

            return Ok(AthletesMessages.CompletedRequest);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, BookingServiceMessages.CreateBookingError);
            throw;
        }
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
