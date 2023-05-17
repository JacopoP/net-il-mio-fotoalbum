using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class PhotoFormModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Il titolo deve essere compreso tra 2 e 50 caratteri")]
        public string Title { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio!")]
        [IsAnImgValidation]
        public IFormFile Img { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio!")]
        public bool Visibile { get; set; }
        public List<Category>? AllCategories { get; set; }
        public List<int>? SelectedCategories { get; set; }

        public PhotoFormModel() 
        {
            SelectedCategories = new List<int>();
        }
    }
}
