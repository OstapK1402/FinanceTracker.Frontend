using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using Task12.BLL.DTO;
using Task12.BLL.Helpers;
using Task12.BLL.IService;

namespace Task12.BLL.Service
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpResponseValidator _responseValidator;

        public TransactionTypeService(HttpClient httpClient, HttpResponseValidator responseValidator)
        {
            _httpClient = httpClient;
            _responseValidator = responseValidator;
        }

        public async Task<IEnumerable<TransactionsTypeDTO>> GetAllTransactionsTypes(CancellationToken token)
        {
            var response = await _httpClient.GetAsync(
                "/api/TransactionsType", 
                token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<TransactionsTypeDTO>>();
            return result;

            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadFromJsonAsync<IEnumerable<TransactionsTypeDTO>>();

            //    return result;
            //}
            //else
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            //}
        }

        public async Task<TransactionsTypeDTO> GetTransactionsTypeById(int id, CancellationToken token)
        {
            var response = await _httpClient.GetAsync(
                $"/api/TransactionsType/{id}", 
                token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadFromJsonAsync<TransactionsTypeDTO>();
            return result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadFromJsonAsync<TransactionsTypeDTO>();
            //    return result;
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new InvalidOperationException($"Not Found: {errorMessage}");
            //}
            //else
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            //}
        }

        public async Task<string> CreateTransactionsType(TransactionsTypeDTO data, CancellationToken token)
        {
            var response = await _httpClient.PostAsync(
                "/api/TransactionsType", 
                new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), 
                token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadAsStringAsync();
            return result;

            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadAsStringAsync();
            //    return result;
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new InvalidOperationException($"Conflict: {errorMessage}");
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new InvalidOperationException($"Bad Request: {errorMessage}");
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new InvalidOperationException($"Internal Server Error: {errorMessage}");
            //}
            //else
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            //}
        }

        public async Task<string> UpdateTransactionsType(int id, TransactionsTypeDTO data, CancellationToken token)
        {
            var response = await _httpClient.PutAsync(
                $"/api/TransactionsType/{id}", 
                new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), 
                token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadAsStringAsync();
            return result;

            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadAsStringAsync();
            //    return result;
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new InvalidOperationException($"Not Found: {errorMessage}");
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new InvalidOperationException($"Bad Request: {errorMessage}");
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new InvalidOperationException($"Internal Server Error: {errorMessage}");
            //}
            //else
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            //}
        }

        public async Task<string> DeleteTransactionsType(int id, CancellationToken token)
        {
            var response = await _httpClient.DeleteAsync(
                $"/api/TransactionsType/{id}",
                token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadAsStringAsync();
            return result;

            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadAsStringAsync();
            //    return result;
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new InvalidOperationException($"Not Found: {errorMessage}");
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new InvalidOperationException($"Bad Request: {errorMessage}");
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new InvalidOperationException($"Internal Server Error: {errorMessage}");
            //}
            //else
            //{
            //    var errorMessage = await response.Content.ReadAsStringAsync();
            //    throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            //}
        }
    }
}
