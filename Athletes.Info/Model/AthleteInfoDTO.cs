using Define.Common;
using System.ComponentModel.DataAnnotations;

namespace Athletes.Info.Model
{
    public record AthleteInfoDTO : AthleteInfoBase
    {
        [Required]
        [Display(Name = "User Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "User City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "User Postal Code")]
        public int PostalCode { get; set; }
        [Required]
        [Display(Name = "User Favorite Activity")]
        public string FavoriteActivity { get; set; }
        [Required]
        [Display(Name = "User Role")]
        public Roles Role { get; set; }
    }
}
