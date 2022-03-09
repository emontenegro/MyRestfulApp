using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRestfulApp.Infraestructure
{
    public interface IUsuariosRepository
    {
        Task<DataContext.DbModels.Usuario> Get(int id);

        Task<IEnumerable<DataContext.DbModels.Usuario>> GetAll();

        void Insert(DataContext.DbModels.Usuario usuario);

        void Update(DataContext.DbModels.Usuario usuario);

        void Delete(DataContext.DbModels.Usuario usuario);

        void Delete(int id);
    }
}
