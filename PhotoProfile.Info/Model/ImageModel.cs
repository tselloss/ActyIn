using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PhotoProfile.Info.Model
{
    public class ImageModel
    {
        [Required]
        public IFormFile Image { get; set; }

        public string FileEntity { get; set; }
    }
}
