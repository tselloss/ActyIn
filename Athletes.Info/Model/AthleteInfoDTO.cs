using Define.Common;
using System.ComponentModel.DataAnnotations;

namespace Athletes.Info.Model
{
    public record AthleteInfoDTO : AthletesInfoBase
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string FavoriteActivity { get; set; }
        [Required]
        public Roles Role { get; set; }
    }
}
