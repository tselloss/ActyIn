using Define.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhotoProfile.Info.Interface;
using PhotoProfile.Info.Model;
using Polly;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace PhotoProfile.Info.Repository
{
    public class ImageService : ControllerBase, IFile
    {
        private NpgsqlContext _context;
        private ApplicationFileEntity appFileEntity;
        private readonly ILogger<ImageService> _logger;

        public ImageService(NpgsqlContext context, ILogger logger)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _logger = (ILogger<ImageService>)(logger ?? throw new ArgumentException(nameof(logger)));
        }

        public async Task<IActionResult> GetFile(string username)
        {
            Byte[] b = null;
            FileEntity fileEntity = _context.AthleteImageProfile.FirstOrDefault(_ => _.AthleteName == username);

            if (fileEntity == null)
            {
                return NotFound(FilesMessages.EmptyFileEntity);
            }

            var retryPolicy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(
                    retryCount: 3,
                    sleepDurationProvider: (attemptCount) => TimeSpan.FromSeconds(attemptCount * 2),
                    onRetryAsync: (exception, sleepDuration, attemptNumber, context) =>
                    {
                        _logger.LogInformation(FilesMessages.RetryPolicy);
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
                _logger.LogInformation(FilesMessages.ErrorGetFile + $"{ex}");
                return BadRequest(string.Format(FilesMessages.ErrorGetPhotoProfileMessage));
            }

            return File(b, fileEntity.ContentType);
        }

        public async Task<IActionResult> PostFile(ImageModel request)
        {
            try
            {
                string filename = request.Username + Path.GetExtension(request.Image.FileName);
                var username = getUsername(request.Username);

                FileEntity fileEntity;

                if (!username)
                {
                    fileEntity = new FileEntity()
                    {
                        FileName = filename,
                        ContentType = request.Image.ContentType,
                        AthleteName = request.Username,
                    };
                    fileEntity = _context.AthleteImageProfile.Add(fileEntity).Entity;
                }
                else
                {
                    fileEntity = await _context.AthleteImageProfile
                        .Where(_ => _.AthleteName == request.Username)
                        .FirstOrDefaultAsync(); // Assuming Entity Framework and AthleteImageProfile is IQueryable.

                    if (fileEntity != null)
                    {
                        fileEntity.FileName = filename;
                        fileEntity.ContentType = request.Image.ContentType;
                    }
                }

                await _context.SaveChangesAsync();

                using (FileStream stream = new FileStream(Path.Combine(getImagePath(request.Username), filename), FileMode.Create))
                {
                    await request.Image.CopyToAsync(stream);
                }
                _logger.LogInformation(FilesMessages.PostPhotoProfileSuccess);
            }
            catch (Exception)
            {
                return BadRequest(FilesMessages.PostPhotoProfileError);
            }

            return Ok();
        }


        public async Task<IActionResult> PostApplicationFile(ApplicationImageModel request)
        {
            try
            {
                string filename = request.Sport + Path.GetExtension(request.Image.FileName);
                var sportName = getSport(request.Sport);
                if (!sportName)
                {
                    appFileEntity = new ApplicationFileEntity()
                    {
                        FileName = filename,
                        ContentType = request.Image.ContentType,
                        SportName = request.Sport,
                    };
                    appFileEntity = _context.ApplicationImages.Add(appFileEntity).Entity;
                }
                else
                {
                    appFileEntity = _context.ApplicationImages.Where(_ => _.SportName == appFileEntity.SportName).FirstOrDefault();
                    appFileEntity.FileName = filename;
                    appFileEntity.ContentType = request.Image.ContentType;

                }
                _context.SaveChanges();

                using (FileStream stream = new FileStream(Path.Combine(getApplicationImagePath(request.Sport), filename), FileMode.Create))
                {
                    request.Image.CopyTo(stream);
                }
                _logger.LogInformation(FilesMessages.PostAppPhotoSuccess);
            }
            catch (Exception)
            {
                return BadRequest(string.Format(FilesMessages.PostAppPhotoError));
            }
            return Ok();
        }

        public async Task<IActionResult> GetApplicationFiles(string sportName)
        {
            Byte[] b = null;
            ApplicationFileEntity fileEntity = _context.ApplicationImages.FirstOrDefault(_ => _.SportName == sportName);

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
                        Console.WriteLine(FilesMessages.RetryPolicy);
                        return Task.CompletedTask;
                    }
                );

            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                    b = await System.IO.File.ReadAllBytesAsync(Path.Combine(getApplicationImagePath(sportName), fileEntity.FileName));
                });
                _logger.LogInformation(FilesMessages.AppGetPhotoMessage);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(FilesMessages.ErrorGetFile + $"{ex}");
                return BadRequest(string.Format(FilesMessages.AppErrorGetPhotoMessage));
            }

            return File(b, fileEntity.ContentType);
        }

        private bool getUsername(string username)
        {
            return _context.AthleteImageProfile.Any(_ => _.AthleteName == username);
        }

        private bool getSport(string sport)
        {
            return _context.ApplicationImages.Any(_ => _.SportName == sport);
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

        private string getApplicationImagePath(string sportName)
        {
            string wwwPath = Path.GetFullPath("AppPhotos");
            string path = Path.Combine(wwwPath, "Uploads/" + sportName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
