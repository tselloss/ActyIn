using System.ComponentModel.DataAnnotations;

namespace Athletes.Info.Request.EditRequests
{
    public record AthleteEditLocationRequest
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostalCode { get; set; }
    }
}
