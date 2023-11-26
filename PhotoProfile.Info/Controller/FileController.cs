using Define.Common.Extension.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoProfile.Info.Model;
using System.IO.Abstractions;

namespace MatchActivity.Info.Controller
{
    [Route(ActionNames.Controller)]
    [ApiController]
    public class FileController : ControllerBase
    {
        IFile _file;
        public FileController(IFile file)
        {
            _file = file;
        }

        [HttpPost]
        [Authorize(Roles = "Upload")]
        public async Task<IActionResult> PostFile([FromForm] ImageModel request)
        {
            return await _file.PostFile(this, request);
        }

        [HttpGet("{carId}")]
        [Authorize(Roles = "Download")]
        public async Task<IActionResult> GetFile(int carId)
        {
            return await _file.GetFile(this, carId);
        }
    }
}
}

