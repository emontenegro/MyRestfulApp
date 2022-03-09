using Microsoft.AspNetCore.Mvc;
using MyRestfulApp.Application.Services;
using MyRestfulApp.Domain.Models;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyRestfulApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _usuarioService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _usuarioService.Get(id);
            return Ok(result);
        }

        [HttpPut]
        public void Put([FromBody] UsuarioDto usuario)
        {
            _usuarioService.Insert(usuario);
        }

        [HttpPost]
        public void Post([FromBody] UsuarioDto usuario)
        {
            if (usuario is null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            _usuarioService.Update(usuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _usuarioService.Delete(id);
        }
    }
}
