using AutoMapper;
using MyRestfulApp.Domain.Models;
using MyRestfulApp.Infraestructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRestfulApp.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuariosRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuariosRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> Get(int id)
        {
            var usuario = await _usuarioRepository.Get(id);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<IEnumerable<UsuarioDto>> GetAll()
        {
            var result = await _usuarioRepository.GetAll();
            return _mapper.Map<List<UsuarioDto>>(result);
        }

        public void Insert(UsuarioDto usuario)
        {
            _usuarioRepository.Insert(_mapper.Map<Infraestructure.DataContext.DbModels.Usuario>(usuario));
        }

        public void Update(UsuarioDto usuario)
        {
            _usuarioRepository.Update(_mapper.Map<Infraestructure.DataContext.DbModels.Usuario>(usuario));
        }

        public void Delete(int id)
        {
            _usuarioRepository.Delete(id);
        }

        public void Delete(UsuarioDto usuario)
        {
            _usuarioRepository.Update(_mapper.Map<Infraestructure.DataContext.DbModels.Usuario>(usuario));
        }
    }
}
