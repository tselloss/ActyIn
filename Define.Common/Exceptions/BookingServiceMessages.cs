namespace Define.Common.Exceptions;
public class BookingServiceMessages
{
    public const string CancelExceptionError = "The cancel function on Booking Service is not succeed";
    public const string CancelExceptionSuccess = "The cancel function on Booking Service is succeed";

    public const string GetAllExceptionError = "The get all function on Booking Service is succeed";
    public const string GetAllExceptionSuccess = "The get all function on Booking Service is not succeed";

    public const string GetByIdExceptionError = "The get by ID function on Booking Service is not succeed";
    public const string GetByIdExceptionSuccess = "The get by ID function on Booking Service is  succeed";

    public const string EmptyModel = "The create function on Booking Service is not succeed";

    public const string CreateBookingSucceed = "The creation of Booking is succeed";
    public const string CreateBookingError = "The creation of Booking is not succeed";

    public const string EmptyBookingsList = "We have no any bookings on our DB";
    public const string EmptyBookingsByID = "We have no any bookings on our DB fro your id: ";
}

