using System;

namespace TimeTracking.ReportGenerator.Models.Requests
{
    public class ReportGeneratorRequest
    {
        public  Guid UserId { get; set; }
        public  Guid ProjectId { get; set; }
    }
}