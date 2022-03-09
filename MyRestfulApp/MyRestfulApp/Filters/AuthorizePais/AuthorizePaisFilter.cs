using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRestfulApp.API.Filters
{
    public class AuthorizePaisFilter : Attribute, IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;
        private readonly List<string> _unauthorizedPaises;

        public AuthorizePaisFilter(IConfiguration configuration)
        {
            _configuration = configuration;
            _unauthorizedPaises = configuration.GetSection("Settings:Unauthorized").Value.Split(',').ToList();
        }

        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isUnauthorized = CheckPaisPermission(context.HttpContext.Request.RouteValues.Values.ToList().Last().ToString(), _unauthorizedPaises);
            if (isUnauthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
        private bool CheckPaisPermission(string request, List<string> permission)
        {
            return permission.Contains(request, StringComparer.OrdinalIgnoreCase);
        }
    }
}
