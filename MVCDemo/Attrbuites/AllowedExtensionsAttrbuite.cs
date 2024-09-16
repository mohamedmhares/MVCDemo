using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Attrbuites
{
    public class AllowedExtensionsAttrbuite : ValidationAttribute
    {
        private readonly string _allowedExtensions;
        public AllowedExtensionsAttrbuite(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as FormFile;
            if (file != null) 
            {
                var extenstion = Path.GetExtension(file.FileName);
                var isAllowed = _allowedExtensions.Split(',').Contains(extenstion, StringComparer.OrdinalIgnoreCase);
                if (!isAllowed) 
               {
                    return new ValidationResult($"Only {_allowedExtensions} are Allowed ");
               }
            }
            return ValidationResult.Success;
        }
    }
}
