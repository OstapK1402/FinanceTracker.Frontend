using System.Net.Http.Json;
using Task12.BLL.DTO;
using Task12.BLL.Interface;
using Task12.BLL.IService;

namespace Task12.BLL.Service
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpResponseValidator _responseValidator;

        public ReportService(HttpClient httpClient, IHttpResponseValidator responseValidator) 
        {
            _httpClient = httpClient;
            _responseValidator = responseValidator;
        }

        public async Task<DailyReport> GetReportByDate(DateTime date, CancellationToken token)
        {
            var strDate = date.Date.ToString("yyyy.MM.dd");

            var response = await _httpClient.GetAsync($"/api/Report/{strDate}", token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadFromJsonAsync<DailyReport>();
            return result;
        }

        public async Task<PeriodReport> GetReportByPeriod(DateTime startDate, DateTime endDate, CancellationToken token)
        {
            var response = await _httpClient.GetAsync($"/api/Report/by-period?startDate={startDate.Date}&endDate={endDate.Date}", token);

            await _responseValidator.ValidateAsync(response);

            var result = await response.Content.ReadFromJsonAsync<PeriodReport>();
            return result;
        }
    }
}
