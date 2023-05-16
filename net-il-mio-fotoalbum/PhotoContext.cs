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

        public PhotoContext(DbContextOptions<PhotoContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DotNetPhotoAbum;Integrated Security=True; TrustServerCertificate = True");
        }

        public PhotoContext() { }
    }
}
