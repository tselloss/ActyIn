using Microsoft.AspNetCore.Mvc;
using Postgres.Context.Entities;

namespace BookingModel.Info.Interface;

public interface IBookingInfo
{
    Task<IEnumerable<BookingEntity>> GetAllBookingsAsync();
    Task<BookingEntity> GetBookingOfAthletesInfoByIdAsync(int athleteId);
    IActionResult CreateABooking(BookingEntity bookingEntity);
    void CancelBooking(BookingEntity bookingEntity);
}
