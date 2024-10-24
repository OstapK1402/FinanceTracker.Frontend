using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Task12.BLL.Exceptions
{
    public class ExceptionHandlingMiddleware
    { 
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionMessageAsync(context, ex, HttpStatusCode.NotFound);
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionMessageAsync(context, ex, HttpStatusCode.BadRequest);
            }
            catch (ConflictException ex)
            {
                await HandleExceptionMessageAsync(context, ex, HttpStatusCode.Conflict);
            }
            catch (InternalServerErrorException ex)
            {
                await HandleExceptionMessageAsync(context, ex, HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex, HttpStatusCode.InternalServerError);
            }
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var result = JsonConvert.SerializeObject(new
            {
                StatusCode = statusCode,
                ErrorMEssage = exception.Message
            });

            return context.Response.WriteAsync(result);
        }
    }
}
