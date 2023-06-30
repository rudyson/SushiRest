using SushiRest.Api.Entities;
using SushiRest.Api.Models;

namespace SushiRest.Api.Repositories.Services;

public interface IImageRepository
{
    public Task<DbImage?> UploadImageAsync(FileToUpload file);
    public Task<DbImage?> GetImageAsync(Guid imageId);
    public Task<DbImage?> GetImageAsync(string imageName);
    public Task<byte[]?>? LoadImageAsync(DbImage image);
}