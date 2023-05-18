using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum
{
    public class PhotoContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Photo> photos { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<ImageEntry> images { get; set; }

        public PhotoContext(DbContextOptions<PhotoContext> options) : base(options) { }

    }
}
