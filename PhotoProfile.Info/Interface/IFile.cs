using Microsoft.AspNetCore.Mvc;
using PhotoProfile.Info.Model;

namespace PhotoProfile.Info.Interface
{
    public interface IFile
    {
        //Task<IActionResult> PostFile(ImageModel request);
        Task<IActionResult> GetFile(string username);
    }
}
