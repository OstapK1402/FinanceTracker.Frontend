using System.Net.Http.Json;
using Task12.BLL.DTO;

namespace Task12.BLL.Service
{
    public class ReportService
    {
        private readonly HttpClient _httpClient;

        public ReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DailyReport> GetReportByDate(DateTime date, CancellationToken token)
        {
            var strDate = date.Date.ToString("yyyy.MM.dd");

            var response = await _httpClient.GetAsync($"/api/Report/{strDate}", token);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<DailyReport>();

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

        public async Task<PeriodReport> GetReportByPeriod(DateTime startDate, DateTime endDate, CancellationToken token)
        {
            var response = await _httpClient.GetAsync($"/api/Report/by-period?startDate={startDate.Date}&endDate={endDate.Date}", token);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<PeriodReport>();

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
    }
}
