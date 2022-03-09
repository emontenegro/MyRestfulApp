using MyRestfulApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRestfulApp.Application.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> Get(int id);
        Task<IEnumerable<UsuarioDto>> GetAll();
        void Insert(UsuarioDto usuario);
        void Update(UsuarioDto usuario);
        void Delete(int id);
        void Delete(UsuarioDto usuario);
    }
}
