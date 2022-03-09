using MediatR;
using MyRestfulApp.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestfulApp.Application.Queries.SearchStrategy
{
    public class GetSearchQuery : IRequest<SearchResponse>
    {
        public string Busqueda { get; set; }
    }
}
