using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    public class ImageEntry
    {
        [Key] public int Id { get; set; }
        public byte[] Data { get; set; }
    }
}
