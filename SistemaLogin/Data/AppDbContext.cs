using Microsoft.EntityFrameworkCore;
using SistemaLogin.Models;

namespace SistemaLogin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
