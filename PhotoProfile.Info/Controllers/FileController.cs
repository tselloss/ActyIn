using Define.Common.Extension.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoProfile.Info.Model;
using IFile = PhotoProfile.Info.Interface.IFile;

namespace PhotoProfile.Info.Controllers
{
    [Route(ActionNames.Controller)]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFile _file;
        public FileController(IFile file)
        {
            _file = file;
        }

        [HttpPost]
        [Authorize(Roles = "Upload")]
        public async Task<IActionResult> PostFile([FromForm] ImageModel request , string username)
        {
            return await _file.PostFile(request, username);
        }

        [HttpGet("{carId}")]
        [Authorize(Roles = "Download")]
        public async Task<IActionResult> GetFile(string username)
        {
            return await _file.GetFile(username);
        }
    }
}


