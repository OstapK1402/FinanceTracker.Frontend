using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using Task12.BLL.DTO;

namespace Task12.BLL.Service
{
    public class FinancialOperationService
    {
        private readonly HttpClient _httpClient;

        public FinancialOperationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<FinancialOperationDTO>> GetAllFinancialOperations(CancellationToken token)
        {
            var response = await _httpClient.GetAsync("/api/FinancialOperation", token);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<FinancialOperationDTO>>();

                return result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Bad Request: {errorMessage}");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            }
        }

        public async Task<FinancialOperationDTO> GetFinancialOperationById(int id, CancellationToken token)
        {
            var response = await _httpClient.GetAsync($"/api/FinancialOperation/{id}", token);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<FinancialOperationDTO>();

                return result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Bad Request: {errorMessage}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Not Found: {errorMessage}");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            }
        }

        public async Task<string> CreateFinancialOperation(FinancialOperationDTO data, CancellationToken token)
        {
            var response = await _httpClient.PostAsync("/api/FinancialOperation", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), token);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Client Error: {errorMessage}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Bad Request: {errorMessage}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Internal Server Error: {errorMessage}");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            }
        }


        public async Task<string> UpdateFinancialOperation(int id, FinancialOperationDTO data, CancellationToken token)
        {
            var response = await _httpClient.PutAsync($"/api/FinancialOperation/{id}", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), token);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Client Error: {errorMessage}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Not Found: {errorMessage}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Bad Request: {errorMessage}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Internal Server Error: {errorMessage}");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            }
        }

        public async Task<string> DeleteFinancialOperation(int id, CancellationToken token)
        {
            var response = await _httpClient.DeleteAsync($"/api/FinancialOperation/{id}", token);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Not Found: {errorMessage}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Bad Request: {errorMessage}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Internal Server Error: {errorMessage}");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            }
        }
    }
}
