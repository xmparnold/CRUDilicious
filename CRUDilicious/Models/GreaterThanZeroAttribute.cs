using System.ComponentModel.DataAnnotations;

public class GreaterThanZeroAttribute : ValidationAttribute {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) {
            return new ValidationResult("value must not be null.");
        }
        if ((int)value <= 0) {
            return new ValidationResult("Value must be greater than 0.");
        }
        return ValidationResult.Success;
    }
}