using Microsoft.EntityFrameworkCore;

namespace Projeto2_NIF_Web_API.Models
{
    public class NIFDbContext : DbContext
    {
        public NIFDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<NIF_Empresa> NIF_Empresa { get; set; }
    }
}
