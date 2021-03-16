using System;
using TimeTracking.Common.Enums;

namespace TimeTracking.ReportGenerator.Entities
{
    public class WorkLog
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public  ActivityType ActivityType { get; set; }
        public  Guid ReportId   { get; set; }
        public  Report Report   { get; set; }
    }
}