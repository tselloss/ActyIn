using Athletes.Info.Model;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Athletes.Info.Request.EditRequests
{
    public record AthleteEditProfileImage
    {
        [Required]
        public IFormFile ProfileImage { get; set; }
    }
}
