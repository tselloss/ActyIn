using Athletes.Info.Model;

namespace Athletes.Info.Request
{
    public record AthleteLoginRequest : AthleteInfoBase
    {
        public string Password { get; set; }
    }
}
