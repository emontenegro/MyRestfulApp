using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRestfulApp.API.Filters;
using MyRestfulApp.Application.Queries.CountriesStrategy;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyRestfulApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaisesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: <PaisesController>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "AR", "BR", "CO" };
        }

        [TypeFilter(typeof(AuthorizePaisFilter))]
        // GET <PaisesController>/AR
        [HttpGet("{idPais}")]
        public IActionResult Get(string idPais)
        {
            return Ok(_mediator.Send(new GetCountryQuery() { Country = idPais}));
        }
    }
}
