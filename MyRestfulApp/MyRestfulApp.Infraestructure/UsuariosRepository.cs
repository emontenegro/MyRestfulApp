using MyRestfulApp.Infraestructure.DataContext;
using MyRestfulApp.Infraestructure.DataContext.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.Infraestructure
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AppDBContext _appDBContext;

        public UsuariosRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<Usuario> Get(int id)
        {
            return await Task.Run(() => _appDBContext.Usuarios.FirstOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await Task.Run(() => _appDBContext.Usuarios);
        }

        public void Insert(Usuario usuario)
        {
            _appDBContext.Usuarios.Add(usuario);
            _appDBContext.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            var entity = _appDBContext.Usuarios.FirstOrDefault(x => x.Id == usuario.Id);

            if (entity != null)
            {
                if (!string.IsNullOrEmpty(usuario.Nombre)) { entity.Nombre = usuario.Nombre; }
                if (!string.IsNullOrEmpty(usuario.Apellido)) { entity.Apellido = usuario.Apellido; }
                if (!string.IsNullOrEmpty(usuario.Email)) { entity.Email = usuario.Email; }
                if (!string.IsNullOrEmpty(usuario.Password)) { entity.Password = usuario.Password; }

                // context.Products.Update(entity);

                _appDBContext.SaveChanges();
            }
        }

        public void Delete(Usuario usuario)
        {
            _appDBContext.Usuarios.Remove(usuario);
            _appDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _appDBContext.Usuarios.Remove(Get(id).Result);
            _appDBContext.SaveChanges();
        }
    }
}
