using System;
using System.Collections.Generic;

namespace TimeTracking.ReportGenerator.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public ICollection<WorkLog> WorkLogs { get; set; }
    }
}