using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class IsAnImgValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            IFormFile img = (IFormFile)value;
            int index = img.FileName.LastIndexOf('.');
            string ext = img.FileName.Substring(index + 1);
            if(ext == "jpg" ||  ext == "png" || ext == "svg" || ext == "webp" || ext == "jpeg")
                return ValidationResult.Success;
            return new ValidationResult("Formato del file caricato non valido. Formati validi: png, jpg, jpeg, webp, svg");
        }
    }
}
