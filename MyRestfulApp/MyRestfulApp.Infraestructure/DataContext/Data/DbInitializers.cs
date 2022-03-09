using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MyRestfulApp.Infraestructure.DataContext.Data
{
    public static class DbInitializers
    {
        public static void Initialize()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: "DbUsuarios")
                .Options;
            using(var _context = new AppDBContext(options))
            {
                if (_context.Usuarios.Any())
                {
                    return;
                }
                _context.Usuarios.AddRange(
                    new DbModels.Usuario { Id = 30, Nombre = "User_Test_0", Apellido = "User_Test_0", Email = "UserTest0@testing.com", Password = "UserTesting0"},
                    new DbModels.Usuario { Id = 31, Nombre = "User_Test_1", Apellido = "User_Test_1", Email = "UserTest1@testing.com", Password = "UserTesting1"},
                    new DbModels.Usuario { Id = 32, Nombre = "User_Test_2", Apellido = "User_Test_2", Email = "UserTest2@testing.com", Password = "UserTesting2"},
                    new DbModels.Usuario { Id = 33, Nombre = "User_Test_3", Apellido = "User_Test_3", Email = "UserTest3@testing.com", Password = "UserTesting3"}
                    );
                _context.SaveChanges();
            }
        }
    }
}
