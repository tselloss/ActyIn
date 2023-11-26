using Athletes.Info.Request.EditRequests;
using Microsoft.AspNetCore.Mvc;
using Postgres.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingModel.Info.Interface
{
    public interface IBookingInfo
    {
        Task<IEnumerable<BookingEntity>> GetAllBookingsAsync();
        Task<BookingEntity> GetBookingOfAthletesInfoByIdAsync(int athleteId);
        IActionResult CreateABooking(BookingEntity bookingEntity);
        void CancelBooking(BookingEntity bookingEntity);
    }
}
