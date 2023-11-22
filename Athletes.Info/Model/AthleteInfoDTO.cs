using Define.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Athletes.Info.Model
{
    public record AthleteInfoDTO : AthleteInfoBase
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string FavoriteActivity { get; set; }
        public Roles Role { get; set; }

        public IFormFile ProfileImage { get; set; }
    }
}
