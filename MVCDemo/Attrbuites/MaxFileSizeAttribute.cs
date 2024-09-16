using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Attrbuites
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _MaxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _MaxFileSize = maxFileSize;
        }
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as FormFile;
            if (file != null)
            {
              
                if (file.Length > _MaxFileSize)
                {
                    return new ValidationResult($"Maximum Allowed size is {_MaxFileSize} bytes ");
                }
            }
            return ValidationResult.Success;
        }
    }
}