using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task12.BLL.Exceptions;
using Task12.BLL.Interface;

namespace Task12.BLL.Helpers
{
    public class HttpResponseValidator : IHttpResponseValidator
    {
        public async Task ValidateAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            var errorMessage = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    throw new NotFoundException($"Not Found: {errorMessage}");

                case System.Net.HttpStatusCode.BadRequest:
                    throw new BadRequestException($"Bad Request: {errorMessage}");

                case System.Net.HttpStatusCode.Conflict:
                    throw new ConflictException($"Conflict: {errorMessage}");

                case System.Net.HttpStatusCode.InternalServerError:
                    throw new InternalServerErrorException($"Internal Server Error: {errorMessage}");

                default:
                    throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            }

        }
    }
}
