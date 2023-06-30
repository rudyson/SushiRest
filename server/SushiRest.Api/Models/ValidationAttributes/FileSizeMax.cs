using System.ComponentModel.DataAnnotations;

namespace SushiRest.Api.Models.ValidationAttributes;

public class FileSizeMaxAttribute: ValidationAttribute
{
    private readonly long _maxFileSize;
    public FileSizeMaxAttribute(long maxFileSize)
    {
        _maxFileSize = maxFileSize;
    }

    protected override ValidationResult IsValid(
        object value,
        ValidationContext validationContext
        )
    {
        var file = value as IFormFile;
        if (file != null)
        {
            if (file.Length > _maxFileSize)
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }

    private new string ErrorMessage => $"Maximum allowed file size is { _maxFileSize} bytes.";
}