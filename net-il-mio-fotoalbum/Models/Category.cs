using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Il nome deve essere compreso tra 3 e 50 caratteri")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio!")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "La descrizione deve essere compresa tra 5 e 150 caratteri")]
        public string Description { get; set; }
        public List<Photo>? Photos { get; set; }

        public Category(){}
    }
}
