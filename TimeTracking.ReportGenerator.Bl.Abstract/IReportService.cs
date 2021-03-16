using System.Threading.Tasks;
using TimeTracking.Common.Wrapper;
using TimeTracking.ReportGenerator.Models;
using TimeTracking.ReportGenerator.Models.Responces;

namespace TimeTracking.ReportGenerator.Bl.Abstract
{
    public interface IReportService
    {
        Task<ApiResponse<ReportExporterResponse>> GenerateReportAsync(ReportConfiguration reportConfiguration);
    }
}