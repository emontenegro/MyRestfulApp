using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRestfulApp.Application.Queries.SearchStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyRestfulApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {

        private readonly IMediator _mediator;
        public BusquedaController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET api/<ValuesController>/5
        [HttpGet("{busqueda}")]
        public IActionResult Get(string busqueda)
        {
            return Ok(_mediator.Send(new GetSearchQuery() { Busqueda = busqueda }));
        }
    }
}
