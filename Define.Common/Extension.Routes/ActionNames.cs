namespace Define.Common.Extension.Routes;

public static class ActionNames
{
    public const string Controller = "actyin/[controller]";

    public const string RegisterUser = "actyin/registerUser";
    public const string LoginUser = "actyin/loginUser";
    public const string DeleteUser = "actyin/deleteUserById/{id}";

    public const string GetUserById = "actyin/getUserById/{id}";
    public const string GetUserByUsername = "actyin/getUserByUsername";
    public const string GetAllUsers = "actyin/getAllUsers";

    public const string EditFavoriteActivity = "actyin/editFavoriteActivity";
    public const string EditAthleteLocation = "actyin/editAthleteLocation";
    public const string EditAthletePassword = "actyin/editAthletePassword";
    public const string EditAthleteUsernameAndEmailRequest = "actyin/editAthleteUsernameAndEmailRequest";
    public const string EditAthleteInfo = "actyin/editAthleteInfo";

    public const string GetAllChosenActivities = "actyin/getAllChosenActivities";
    public const string GetChosenActivitiesById = "actyin/getChosenActivitiesById";
    public const string DeleteActivityUser = "actyin/deleteActivityUser";
    public const string CreateNewActivity = "actyin/createNewActivity";
    public const string GetChosenActivitiesByDate = "actyin/getChosenActivitiesByDate";

    public const string GetAllMatchModel = "actyin/getMatchModel";
    public const string SaveMatchModel = "actyin/saveMatchModel";
    public const string GetMatchModelById = "actyin/getMatchModelById";
    public const string DeleteMatchModel = "actyin/deleteMatchModel";


    public const string GetAllBookings = "actyin/getBookings";
    public const string SaveBooking = "actyin/saveBooking";
    public const string GetBookingsById = "actyin/getBookingsById";
    public const string GetBookingsByUsername = "actyin/getBookingsByUsername";
    public const string CancelBooking = "actyin/cancelBooking";
}
