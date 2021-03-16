using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTracking.Common.Jwt;
using TimeTracking.ReportGenerator.Bl.Abstract;
using TimeTracking.ReportGenerator.Bl.Impl.Services;
using TimeTracking.ReportGenerator.Bl.Impl.Settings;

namespace TimeTracking.ReportGenerator.Bl.Impl
{
    public static class BalDependencyInstaller
    {
        public static IServiceCollection AddBlLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IReportExporter, ReportExporter>();
            services.AddTransient<IWorkLogClientService, WorkLogClientService>();
            services.AddConfig(configuration);
            return services;
        }
        
        private static IServiceCollection AddConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<TimeTrackingClientSettings>(configuration.GetSection(nameof(TimeTrackingClientSettings)));
            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
            return services;
        }  
    }
}