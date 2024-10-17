using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Task12.Data;
using Task12.Data.Service;

namespace Task12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            var baseUrl = new Uri(builder.Configuration.GetSection("ApiSettings:BaseUrl").Get<string>());

            builder.Services.AddHttpClient<TransactionTypeService>(client =>{ client.BaseAddress = baseUrl; });
            builder.Services.AddHttpClient<FinancialOperationService>(client => { client.BaseAddress = baseUrl; });
            builder.Services.AddHttpClient<ReportService>(client => { client.BaseAddress = baseUrl; });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}