using Define.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhotoProfile.Info.Interface;
using PhotoProfile.Info.Model;
using Polly;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;
using System.Security.Claims;

namespace PhotoProfile.Info.Repository
{
    public class ImageService : ControllerBase, IFile
    {
        private NpgsqlContext _context;
        private IHttpContextAccessor _httpContext;

        public ImageService(NpgsqlContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<IActionResult> GetFile(string username)
        {
            Byte[] b = null;
            FileEntity fileEntity = _context.AthleteImageProfile.FirstOrDefault(_ => _.AthleteName == username);

            if (fileEntity == null)
            {
                return NotFound(AthletesExceptionMessages.UndefinedUserEmail);
            }

            var retryPolicy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(
                    retryCount: 3,
                    sleepDurationProvider: (attemptCount) => TimeSpan.FromSeconds(attemptCount * 2),
                    onRetryAsync: (exception, sleepDuration, attemptNumber, context) =>
                    {
                        Console.WriteLine("Retry Policy");
                        return Task.CompletedTask;
                    }
                );

            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                    b = await System.IO.File.ReadAllBytesAsync(Path.Combine(getImagePath(username), fileEntity.FileName));
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return BadRequest(string.Format("Something gone wrong"));
            }

            return File(b, fileEntity.ContentType);
        }

        public async Task<IActionResult> PostFile(ImageModel request, string username)
        {
            try
            {
                FileEntity fileEntity = JsonConvert.DeserializeObject<FileEntity>(request.FileEntity);
                string filename = username + Path.GetExtension(request.Image.FileName);
                if (!_context.AthleteImageProfile.Any(_ => _.AthleteName == fileEntity.AthleteName))
                {
                    fileEntity = new FileEntity()
                    {
                        FileName = filename,
                        ContentType = request.Image.ContentType,
                        AthleteName = username,
                    };
                    fileEntity = _context.AthleteImageProfile.Add(fileEntity).Entity;
                }
                else
                {
                    fileEntity = _context.AthleteImageProfile.Where(_ => _.AthleteName == fileEntity.AthleteName).FirstOrDefault();
                    fileEntity.FileName = filename;
                    fileEntity.ContentType = request.Image.ContentType;

                }
                _context.SaveChanges();

                using (FileStream stream = new FileStream(Path.Combine(getImagePath(username), fileEntity.FileName), FileMode.Create))
                {
                    request.Image.CopyTo(stream);
                }

            }
            catch (Exception)
            {
                return BadRequest(string.Format("Something gone wrong"));
            }
            return Ok();
        }

        private string getImagePath(string username)
        {
            string wwwPath = Path.GetFullPath("photoProfile");
            string path = Path.Combine(wwwPath, "Uploads/" + username);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
