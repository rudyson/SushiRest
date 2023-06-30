using System.ComponentModel.DataAnnotations;

namespace SushiRest.Api.Models.ValidationAttributes;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;

    private static readonly Dictionary<string, List<byte[]>> _fileSignatures = new()
    {
        {
            ".gif",
            new List<byte[]>
            {
                new byte[] { 0x47, 0x49, 0x46, 0x38 }
            }
        },
        {
            ".png",
            new List<byte[]>
            {
                new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }
            }
        },
        {
            ".jpeg",
            new List<byte[]>
            {
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xEE },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xDB },
            }
        },
        {
            ".jpeg2000",
            new List<byte[]>
            {
                new byte[]{ 0x00, 0x00, 0x00, 0x0C, 0x6A, 0x50, 0x20, 0x20, 0x0D, 0x0A, 0x87, 0x0A }
            }
        },

        {
            ".jpg", new List<byte[]>
            {
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xEE },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xDB },
            }
        }
    };
    public AllowedExtensionsAttribute(string[] extensions)
    {
        _extensions = extensions;
    }
    
    protected override ValidationResult IsValid(
        object value,
        ValidationContext validationContext
        )
    {
        var file = value as IFormFile;
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!_extensions.Contains(extension.ToLower()))
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        
        return ValidationResult.Success;
    }
    private new string ErrorMessage => "This photo extension is not allowed!";
}