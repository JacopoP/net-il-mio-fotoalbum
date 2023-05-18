using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio!")]
        [EmailAddress(ErrorMessage = "Inserisci una email valida")] 
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio!")]
        [StringLength(250, ErrorMessage = "Lunghezza massima della descrizione: 250 caratteri")]
        public string Text { get; set; }

        public Message(string email, string text)
        {
            Email = email;
            Text = text;
        }

        public Message() { }
        public string? UserID { get; set; }

        public IdentityUser? User { get; set; }
    }
}
