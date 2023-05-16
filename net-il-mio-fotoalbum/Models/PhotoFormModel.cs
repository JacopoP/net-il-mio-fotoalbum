using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class PhotoFormModel
    {
        [Required(ErrorMessage = "Campo obbligatorio!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Il titolo deve essere compreso tra 2 e 50 caratteri")]
        public string Title { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
        [Required]
        [IsAnImgValidation]
        public IFormFile Img { get; set; }
        [Required]
        public bool visibile { get; set; }
        public List<Category> AllCategories { get; set; }
        public List<int> SelectedCategories { get; set; }
    }
}
