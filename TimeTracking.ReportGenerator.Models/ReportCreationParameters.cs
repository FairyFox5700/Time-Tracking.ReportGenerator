using System;
using TimeTracking.Common.Enums;

namespace TimeTracking.ReportGenerator.Models
{
    public class ReportCreationParameters
    {
        public ReportType ReportType { get; set; }
        public string ProjectName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
    }
}