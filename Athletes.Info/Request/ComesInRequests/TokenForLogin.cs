using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athletes.Info.Request.ComesInRequests
{
    public record TokenForLogin : AthleteLoginRequest
    {
        public string Token { get; set; }
    }
}
