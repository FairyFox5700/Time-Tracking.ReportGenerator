using System;
using TimeTracking.Common.Enums;

namespace TimeTracking.ReportGenerator.Models
{
    public class ReportConfiguration
    {
        public ReportFormatType ReportFormatType { get; set; }
        public  ReportCreationParameters ReportParameters { get; set; }
    }

    public enum ReportFormatType
    {
        Pdf, 
        Excel,
    }

 
}