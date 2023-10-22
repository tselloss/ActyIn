using System.ComponentModel.DataAnnotations;

namespace Athletes.Info.Model
{
    public record AthleteInfoBase
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$")]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
