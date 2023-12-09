using AutoMapper;
using Define.Common.Extension.Routes;
using Microsoft.AspNetCore.Mvc;
using PhotoProfile.Info.Model;
using IFile = PhotoProfile.Info.Interface.IFile;

namespace PhotoProfile.Info.Controllers;
[Route(ActionNames.Controller)]
[ApiController]
public class FileController : ControllerBase
{
    private readonly IFile _file;
    private readonly IMapper _mapper;

    public FileController(IFile file, IMapper mapper)
    {
        _file = file ?? throw new ArgumentException(nameof(file));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpPost]
    public async Task<IActionResult> PostFile([FromForm] ImageModel request)
    {
        var mapper = _mapper.Map<ImageModel>(request);
        return await _file.PostFile(mapper);
    }

    [HttpGet("getPhotoByUsername")]
    public async Task<IActionResult> GetFile(string username)
    {
        return await _file.GetFile(username);
    }

    [HttpPost("applicationPhotos")]
    public async Task<IActionResult> PostFileForApplication([FromForm] ApplicationImageModel request)
    {
        var mapper = _mapper.Map<ApplicationImageModel>(request);
        return await _file.PostApplicationFile(mapper);
    }

    [HttpGet("getPhotoForSports")]
    public async Task<IActionResult> GetApplicationFilesFile(string sport)
    {
        return await _file.GetApplicationFiles(sport);
    }
}


