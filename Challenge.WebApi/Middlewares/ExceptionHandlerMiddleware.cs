using Challenge.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Challenge.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private const string JsonContentType = "application/json";

        private readonly RequestDelegate _request;

        public ExceptionHandlerMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        /// <summary>
        /// Invokes the specified context
        /// </summary>
        public Task Invoke(HttpContext context) => InvokeAsync(context);

        async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                var _httpStatusCode = ConfigurateExceptionTypes(ex);

                context.Response.StatusCode = ConfigurateExceptionTypes(ex);

                context.Response.ContentType = JsonContentType;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorHandlerViewModel
                {
                    ErrorCode = _httpStatusCode, Message = ex.Message
                }));
            }
        }

        private static int ConfigurateExceptionTypes(Exception exception)
        {
            int _httpStatusCode;

            switch (exception)
            {
                case var ve when exception is ValidationException:
                    // BadRequest for bunisses exceptions.
                    _httpStatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case var ue when exception is UnauthorizedAccessException:
                    _httpStatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                default:
                    // Internal for general exceptions.
                    _httpStatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return _httpStatusCode;
        }
    }
}
