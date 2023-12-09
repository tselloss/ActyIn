namespace Define.Common.Exceptions;

public class AthletesExceptionMessages
{
    public const string UndefinedUserId = "User does not exist for this ID ";
    public const string UndefinedUserEmail = "User does not exist for this Email ";
    public const string UndefinedUserUsername = "User does not exist for this Username ";
    public const string UndefinedUserPassword = "Your password for this Id is not correct or is not exist ";
    public const string UndefinedUsers = "We have no users on our DB ";
    public const string AthleteCanNotCreated = "We can not manage to save your data";
    public const string AthleteCanNotDeleted = "We can not manage to delete your data";
    public const string AthleteHaveSameUsername = "We can not make your registration, another user has this username";
    public const string AthleteHaveSameEmail = "We can not make your registration, another user has this email";
    public const string NullField = "A field is null try again";
}
