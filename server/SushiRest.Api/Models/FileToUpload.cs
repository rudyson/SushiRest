using System.ComponentModel.DataAnnotations;
using SushiRest.Api.Models.ValidationAttributes;

namespace SushiRest.Api.Models;

public class FileToUpload
{
    [Required(ErrorMessage = "Please select a file to upload.")]
    [FileSizeMax(5* 1024 * 1024)]
    [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png" })]
    public IFormFile? Image { get; set; }
}