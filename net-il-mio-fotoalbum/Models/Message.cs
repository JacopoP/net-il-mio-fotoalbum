﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress] 
        public string Email { get; set; }
        [Required]
        [StringLength(250)]
        public string Text { get; set; }

        public Message(string email, string text)
        {
            Email = email;
            Text = text;
        }
        public string UserID { get; set; }

        public IdentityUser User { get; set; }
    }
}
