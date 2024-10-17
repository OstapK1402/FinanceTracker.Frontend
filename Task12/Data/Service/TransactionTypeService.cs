using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using Task12.Data.DTO;

namespace Task12.Data.Service
{
    public class TransactionTypeService
    {
        private readonly HttpClient _httpClient;

        public TransactionTypeService(HttpClient httpClient)       
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TransactionsTypeDTO>> GetAllTransactionsTypes()
        {
            var response = await _httpClient.GetAsync("/api/TransactionsType");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<TransactionsTypeDTO>>();

                return result;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            }
        }

        public async Task<TransactionsTypeDTO> GetTransactionsTypeById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/TransactionsType/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TransactionsTypeDTO>();
                return result;
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

        public async Task<TransactionsTypeDTO> GetTransactionsTypeByIncome(bool isIncome)
        {
            var response = await _httpClient.GetAsync($"/api/TransactionsType/by-income/{isIncome}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TransactionsTypeDTO>();

                return result;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Message: {errorMessage}");
            }
        }

        public async Task<string> CreateTransactionsType(TransactionsTypeDTO data)
        {
            var response = await _httpClient.PostAsync("/api/TransactionsType", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Conflict: {errorMessage}");
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

        public async Task<string> UpdateTransactionsType(int id, TransactionsTypeDTO data)
        {
            var response = await _httpClient.PutAsync($"/api/TransactionsType/{id}", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            
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

        public async Task<string> DeleteTransactionsType(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/TransactionsType/{id}");

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
