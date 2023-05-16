using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Description { get; set; }
        public List<Photo> Photos { get; set; }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
