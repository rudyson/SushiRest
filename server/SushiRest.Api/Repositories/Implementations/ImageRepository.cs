using Microsoft.EntityFrameworkCore;
using SushiRest.Api.Contexts;
using SushiRest.Api.Entities;
using SushiRest.Api.Models;
using SushiRest.Api.Repositories.Services;

namespace SushiRest.Api.Repositories.Implementations;

public class ImageRepository : IImageRepository
{
    private static string? _uploadsPath;
    private readonly SushiRestDbContext _context;
    private readonly ILogger<ImageRepository> _logger;

    public ImageRepository(
        IWebHostEnvironment webHostEnvironment,
        ILogger<ImageRepository> logger,
        SushiRestDbContext context
        )
    {
        _logger = logger;
        _context = context;
        if (string.IsNullOrWhiteSpace(webHostEnvironment.WebRootPath))
            webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        _uploadsPath = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
    }
    public async Task<DbImage?> UploadImageAsync(FileToUpload file)
    {
        if (file.Image == null || _uploadsPath == null || file.Image.Length <= 0)
            return null;
        if (!Directory.Exists(_uploadsPath))
            Directory.CreateDirectory(_uploadsPath);
        var image = await _context.Images!.AddAsync(new DbImage
        {
            Extension = Path.GetExtension(file.Image.FileName)[1..]
        });
        var fileUploadPath = Path.Combine(_uploadsPath, image.Entity.Name);
        await using (var fileStream = File.Create(fileUploadPath))
        {
            await file.Image.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
        }
        await _context.SaveChangesAsync();
        return image.Entity;
    }

    public async Task<DbImage?> GetImageAsync(Guid imageId)
    {
        var image = await _context.Images!.SingleOrDefaultAsync(i => i.Id == imageId);
        return image;
    }

    public async Task<DbImage?> GetImageAsync(string imageName)
    {
        var id = Guid.Parse(Path.GetFileNameWithoutExtension(imageName));
        var image = await _context.Images!.SingleOrDefaultAsync(i => i.Id == id);
        if (image == null) return null;
        return image.Name == imageName ? image : null;
    }

    public async Task<byte[]?>? LoadImageAsync(DbImage image)
    {
        if (_uploadsPath == null)
        {
            _logger.LogWarning("Uploads path is null");
            return null;
        }

        var fileGetPath = Path.Combine(_uploadsPath, image.Name);
        if (!File.Exists(fileGetPath))
        {
            var brokenImage = await _context.Images!.SingleOrDefaultAsync(i => i.Id == image.Id);
            if (brokenImage==null) return null;
            _context.Remove(brokenImage);
            await _context.SaveChangesAsync();
            _logger.LogWarning($"File not found ({fileGetPath}). Removing record.");
            return null;
        }
        var imageBytes = await File.ReadAllBytesAsync(fileGetPath);
        return imageBytes;
    }

    public async Task<bool> DeleteImageAsync(Guid imageId)
    {
        var image = await _context.Images!.SingleOrDefaultAsync(i => i.Id == imageId);
        var fileGetPath = Path.Combine(_uploadsPath, image.Name);
        if (_uploadsPath == null || image==null || !File.Exists(fileGetPath))
            return false;
        File.Delete(fileGetPath);
        _context.Images.Remove(image);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteImageAsync(string imageName)
    {
        var id = Guid.Parse(Path.GetFileNameWithoutExtension(imageName));
        var image = await _context.Images!.SingleOrDefaultAsync(i => i.Id == id);
        if (image == null) return false;
        if (image.Name != imageName) return false;
        var fileGetPath = Path.Combine(_uploadsPath, image.Name);
        File.Delete(fileGetPath);
        _context.Images.Remove(image);
        await _context.SaveChangesAsync();
        return true;
    }
}