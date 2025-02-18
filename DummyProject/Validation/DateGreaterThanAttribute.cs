using System.ComponentModel.DataAnnotations;

public class DateGreaterThanAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public DateGreaterThanAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult(ErrorMessage);

        var currentValue = (DateTime)value;
        var property = validationContext.ObjectType.GetProperty(_comparisonProperty) ?? throw new ArgumentException("Property with this name not found");
        var comparisonValue = property.GetValue(validationContext.ObjectInstance);

        if (comparisonValue == null)
            return ValidationResult.Success;

        if (currentValue <= (DateTime)comparisonValue)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}

