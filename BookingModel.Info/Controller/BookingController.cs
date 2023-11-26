using AutoMapper;
using BookingModel.Info.Interface;
using BookingModel.Info.Model;
using BookingModel.Info.Repository;
using Define.Common.Exceptions;
using Define.Common.Extension.Routes;
using MatchActivity.Info.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Postgres.Context.Entities;

namespace BookingModel.Info.Controller
{
    [Route(ActionNames.Controller)]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingInfo _bookingInfo;
        private readonly ILogger<BookingController> _logger;
        private readonly IMapper _mapper;
        private readonly BookingInfoService _bookingInfoService;

        public BookingController(IBookingInfo bookingInfo, ILogger<BookingController> logger, IMapper mapper, BookingInfoService bookingInfoService)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _bookingInfo = bookingInfo ?? throw new ArgumentException(nameof(bookingInfo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _bookingInfoService = bookingInfoService ?? throw new ArgumentNullException(nameof(bookingInfoService));
        }

        [Authorize]
        [HttpGet(ActionNames.GetAllBookings)]
        public async Task<ActionResult<IEnumerable<BookingModelInfo>>> GetAllBookingsAsync()
        {
            var bookings = await _bookingInfo.GetAllBookingsAsync();
            if (bookings == null)
            {
                _logger.LogInformation("We have no any bookings");
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<BookingModelInfo>>(bookings));
        }

        [Authorize]
        [HttpGet(ActionNames.GetBookingsById)]
        public async Task<ActionResult<BookingModelInfo>> GetBookingInfoByIdAsync(int id)
        {
            var booking = await _bookingInfo.GetBookingOfAthletesInfoByIdAsync(id);
            if (booking == null)
            {
                _logger.LogInformation(AthletesExceptionMessages.UndefinedUserId + $"{id}");
                return NoContent();
            }
            var getUser = _mapper.Map<BookingModelInfo>(booking);
            return Ok(getUser);
        }

        [Authorize]
        [HttpDelete(ActionNames.CancelBooking)]
        public async Task<ActionResult> CancelBooking(int id)
        {
            var booking = await _bookingInfo.GetBookingOfAthletesInfoByIdAsync(id);

            if (booking == null)
            {
                _logger.LogInformation(AthletesExceptionMessages.UndefinedUserId + $"{id}");
                return NoContent();
            }
            var selectedBooking = _mapper.Map<BookingEntity>(booking);
            _bookingInfo.CancelBooking(selectedBooking);

            await _bookingInfoService.SaveChangesAsync(AthletesExceptionMessages.AthleteCanNotDeleted);
            return Ok(booking);
        }

        [HttpPost(ActionNames.SaveBooking)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult SaveMatchModel([FromBody] BookingModelInfo bookingModelInfo)
        {
            var mapper = _mapper.Map<BookingEntity>(bookingModelInfo);
            var entity = _bookingInfoService.CreateABooking(mapper);

            if (entity is BadRequestObjectResult badRequest)
            {
                return BadRequest(new { Error = badRequest.Value });
            }

            return Ok();
        }
    }
}

