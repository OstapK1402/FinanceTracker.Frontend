using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task12.BLL.Service;

namespace Task12.BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBLLService(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = new Uri(configuration.GetSection("ApiSettings:BaseUrl").Value);

            services.AddSingleton<TransactionTypeService>();
            services.AddSingleton<ReportService>();
            services.AddSingleton<FinancialOperationService>();

            services.AddHttpClient<TransactionTypeService>(client => { client.BaseAddress = baseUrl; });
            services.AddHttpClient<FinancialOperationService>(client => { client.BaseAddress = baseUrl; });
            services.AddHttpClient<ReportService>(client => { client.BaseAddress = baseUrl; });

            return services; 
        }
    }
}
