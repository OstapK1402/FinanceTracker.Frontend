using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using Task12.BLL.DTO;
using Task12.BLL.Helpers;
using Task12.BLL.IService;

namespace Task12.BLL.Service
{
    public class FinancialOperationService : IFinancialOperationService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpResponseValidator _responseValidator;

        public FinancialOperationService(HttpClient httpClient, HttpResponseValidator responseValidator)
        {
            _httpClient = httpClient;
            _responseValidator = responseValidator;
        }

        public async Task<IEnumerable<FinancialOperationDTO>> GetAllFinancialOperations(CancellationToken token)
        {
            var response = await _httpClient.GetAsync(
                "/api/FinancialOperation", 
                token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<FinancialOperationDTO>>();
            return result;
        }

        public async Task<FinancialOperationDTO> GetFinancialOperationById(int id, CancellationToken token)
        {
            var response = await _httpClient.GetAsync(
                $"/api/FinancialOperation/{id}", 
                token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadFromJsonAsync<FinancialOperationDTO>();
            return result;
        }

        public async Task<string> CreateFinancialOperation(FinancialOperationDTO data, CancellationToken token)
        {
            var response = await _httpClient.PostAsync(
                "/api/FinancialOperation", 
                new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), 
                token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }


        public async Task<string> UpdateFinancialOperation(int id, FinancialOperationDTO data, CancellationToken token)
        {
            var response = await _httpClient.PutAsync(
                $"/api/FinancialOperation/{id}", 
                new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), 
                token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> DeleteFinancialOperation(int id, CancellationToken token)
        {
            var response = await _httpClient.DeleteAsync(
                $"/api/FinancialOperation/{id}", 
                token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
