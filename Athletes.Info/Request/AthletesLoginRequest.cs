using Athletes.Info.Model;

namespace Athletes.Info.Request
{
    public record AthletesLoginRequest : AthletesInfoBase
    {
        public string Password { get; set; }
    }
}
