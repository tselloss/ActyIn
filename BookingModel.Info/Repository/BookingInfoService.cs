using AutoMapper;
using BookingModel.Info.Interface;
using BookingModel.Info.Model;
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
    private readonly IMapper _mapper;

    public BookingInfoService(NpgsqlContext context, ILogger logger, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        //_logger = (ILogger<BookingInfoService>)(logger ?? throw new ArgumentException(nameof(logger)));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
                //_logger.LogInformation(BookingServiceMessages.CancelExceptionSuccess);
            }
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, BookingServiceMessages.CancelExceptionError);
            throw;
        }
    }

    public async Task<IEnumerable<BookingModelInfo>> GetAllBookingsAsync()
    {
        try
        {
            var getAll = await _context.Bookings.OrderBy(_ => _.BookingId).ToListAsync();
            //_logger.LogInformation(BookingServiceMessages.GetAllExceptionSuccess);
            var results = _mapper.Map<List<BookingModelInfo>>(getAll);
            return results;
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, BookingServiceMessages.GetAllExceptionError);
            throw;
        }
    }

    public async Task<BookingModelInfo> GetBookingOfAthletesInfoByIdAsync(int bookingId)
    {
        try
        {
            var getById = await _context.Bookings.Where(b => !b.IsCanceled).Where(_ => _.BookingId == bookingId).ToListAsync();
            //_logger.LogInformation(BookingServiceMessages.GetByIdExceptionSuccess);
            var mapper = _mapper.Map<BookingModelInfo>(getById);
            return mapper;
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, BookingServiceMessages.GetByIdExceptionError);
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
            // _logger.LogInformation(BookingServiceMessages.CreateBookingSucceed);

            return Ok(AthletesMessages.CompletedRequest);
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, BookingServiceMessages.CreateBookingError);
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

    public async Task<IEnumerable<BookingModelInfo>> GetBookingOfAthletesInfoByUsernameAsync(string username)
    {
        try
        {
            var dateTimeNow = DateTime.Now;
            var getByUsername = await _context.Bookings.Where(b => b.SelectedDate >= dateTimeNow).Where(_ => _.UsernamePicker == username).ToListAsync();
            //_logger.LogInformation(BookingServiceMessages.GetByIdExceptionSuccess);
            var mapper = _mapper.Map<List<BookingModelInfo>>(getByUsername);
            return mapper;
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, BookingServiceMessages.GetByIdExceptionError);
            throw;
        }
    }
}
