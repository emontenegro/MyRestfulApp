using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MyRestfulApp.API.ExceptionMiddleware
{
    public class ServiceExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ServiceExceptionMiddleware(RequestDelegate next, ILogger<ServiceExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpConext)
        {
            try
            {
                await _next(httpConext);
            }
            catch (ArgumentException ex)
            {
                _logger.LogInformation(ex, ex.Message);
                await HandleBadRequestAsync(httpConext, ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                _logger.LogInformation(ex, ex.Message);
                await HandleConflictAsync(httpConext, ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
                await HandleExceptionAsync(httpConext, ex.Message);
            }
        }

        private Task HandleBadRequestAsync(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(new ErrorDetails
            {
                Message = message,
                StatusCode = context.Response.StatusCode
            }.ToString());
        }

        private Task HandleConflictAsync(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            return context.Response.WriteAsync(new ErrorDetails
            {
                Message = message,
                StatusCode = context.Response.StatusCode
            }.ToString());
        }

        private Task HandleExceptionAsync(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails { 
                Message = message,
                StatusCode = context.Response.StatusCode
            }.ToString());
        }
    }
}
