using System;
using System.Collections.Generic;
using TimeTracking.Common.Enums;

namespace TimeTracking.ReportGenerator.Models
{
    public class UserActivityDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail{ get; set; }
        public long TotalWorkLogInSeconds { get; set; }
        public string ProjectName { get; set; }
        public List<WorkLogDto> WorkLogItems { get; set; }
    }
    public class WorkLogDto
    {
        public  string Description { get; set; }
        public  TimeSpan TimeSpent { get; set; }
        public  ActivityType ActivityType { get; set; }
        public  DateTimeOffset StartDate { get; set; }
        public  Guid IssueId { get; set; }
    }


}