using System.ComponentModel.DataAnnotations;

namespace BlazorWasmToDo.Attributes;

public class FutureDateTimeOffsetAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTimeOffset dateTimeOffset)
        {
            if (dateTimeOffset > DateTimeOffset.Now)
            {
                return ValidationResult.Success; // why nullable warning?
            }
        }

        return new ValidationResult("The date must be in the future.");
    }
}