using Microsoft.AspNetCore.Http;
using MusicCenter.Application.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCenter.API.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var response = context.Response;

                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status500InternalServerError;
                object result = null;

                switch (e)
                {
                    case UnauthorizedUseCaseException:
                        result = new
                        {
                            message = "You are not authorized to execute this action."
                        };
                        response.StatusCode = StatusCodes.Status401Unauthorized;
                        break;
                    case EntityNotFoundException:
                        result = new
                        {
                            message = "Entity not found."
                        };
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    default:
                        result = new
                        {
                            message = "Internal server error."
                        };
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                await response.WriteAsync(JsonConvert.SerializeObject(result));
                return;
            }
        }
    }
}
