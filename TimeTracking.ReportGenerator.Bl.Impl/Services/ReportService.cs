using System.Threading.Tasks;
using TimeTracking.Common.Wrapper;
using TimeTracking.ReportGenerator.Bl.Abstract;
using TimeTracking.ReportGenerator.Models;
using TimeTracking.ReportGenerator.Models.Requests;
using TimeTracking.ReportGenerator.Models.Responces;

namespace TimeTracking.ReportGenerator.Bl.Impl.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportExporter _reportExporter;
        private readonly IWorkLogClientService _workLogClientService;

        public ReportService(IReportExporter reportExporter, 
            IWorkLogClientService workLogClientService)
        {
            _reportExporter = reportExporter;
            _workLogClientService = workLogClientService;
        }


        public async Task<ApiResponse<ReportExporterResponse>> GenerateReportAsync(ReportConfiguration reportConfiguration)
        {
            var reportGeneratorRequest = new ReportGeneratorRequest()
            {
                ProjectId = reportConfiguration.ReportParameters.ProjectId,
                UserId = reportConfiguration.ReportParameters.UserId,
            };
            var apiResponse = await _workLogClientService.GetUserActivities(reportGeneratorRequest);
            if (!apiResponse.IsSuccess)
            {
                return apiResponse.ToFailed<ReportExporterResponse>();
            }
            var reportExportFile = _reportExporter.GenerateReportForExport(apiResponse.Data,reportConfiguration.ReportFormatType);
            return new ApiResponse<ReportExporterResponse>(reportExportFile);
        }
    }
}