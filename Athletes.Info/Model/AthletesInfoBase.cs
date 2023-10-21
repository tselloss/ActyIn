using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athletes.Info.Model
{
    public record AthletesInfoBase
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
