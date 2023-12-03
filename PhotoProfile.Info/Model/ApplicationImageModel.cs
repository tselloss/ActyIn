using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PhotoProfile.Info.Model
{
    public class ApplicationImageModel
    {
        [Required]
        public IFormFile Image { get; set; }

        [Required] 
        public string Sport { get; set; }
    }
}
