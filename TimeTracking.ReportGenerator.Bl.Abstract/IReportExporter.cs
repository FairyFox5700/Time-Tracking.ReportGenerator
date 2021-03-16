using System.Data;
using TimeTracking.ReportGenerator.Models;
using TimeTracking.ReportGenerator.Models.Responces;

namespace TimeTracking.ReportGenerator.Bl.Abstract
{
    public interface IReportExporter
    {
        ReportExporterResponse GenerateReportForExport(UserActivityDto userActivity, ReportFormatType formatType);
    }
}