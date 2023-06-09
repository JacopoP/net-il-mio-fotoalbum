﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{
    public class Photo
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Il titolo deve essere compreso tra 2 e 50 caratteri")]
        public string Title { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
        [Required]
        public int? ImageID { get; set; }

        public ImageEntry? Image { get; set; }
        [NotMapped] public string? ImageEntryBase64 => Image == null ? "" : "data:image/jpg;base64," + Convert.ToBase64String(Image.Data);
        [Required]
        public bool Visibile { get; set; }
        public List<Category>? categories { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}
