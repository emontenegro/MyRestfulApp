using Microsoft.EntityFrameworkCore;

namespace MyRestfulApp.Infraestructure.DataContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            :base(options)
        {
        }

        public virtual DbSet<DbModels.Usuario> Usuarios { get; set; }
    }
}
