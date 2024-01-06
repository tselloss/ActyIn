namespace Athletes.Info.Request.EditRequests;

public record AthleteEditInfoRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int PostalCode { get; set; }
    public string City { get; set; }
    public string FavoriteActivity { get; set; }
}
