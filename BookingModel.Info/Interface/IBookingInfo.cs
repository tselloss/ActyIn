using BookingModel.Info.Model;
using Microsoft.AspNetCore.Mvc;
using Postgres.Context.Entities;

namespace BookingModel.Info.Interface;

public interface IBookingInfo
{
    Task<IEnumerable<BookingModelInfo>> GetAllBookingsAsync();
    Task<BookingModelInfo> GetBookingOfAthletesInfoByIdAsync(int athleteId);
    Task<IEnumerable<BookingModelInfo>> GetBookingOfAthletesInfoByUsernameAsync(string username);
    IActionResult CreateABooking(BookingEntity bookingEntity);
    void CancelBooking(BookingEntity bookingEntity);
}
