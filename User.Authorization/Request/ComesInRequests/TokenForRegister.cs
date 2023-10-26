namespace User.Authorization.Request.ComesInRequests
{
    public record TokenForRegister : AthleteRegisterRequest
    {
        public string Token { get; set; } = null; 
    }
}
