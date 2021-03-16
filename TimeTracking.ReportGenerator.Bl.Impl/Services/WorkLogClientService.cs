using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TimeTracking.Common.Wrapper;
using TimeTracking.ReportGenerator.Bl.Abstract;
using TimeTracking.ReportGenerator.Bl.Impl.Heplers;
using TimeTracking.ReportGenerator.Bl.Impl.Settings;
using TimeTracking.ReportGenerator.Models;
using TimeTracking.ReportGenerator.Models.Requests;

namespace TimeTracking.ReportGenerator.Bl.Impl.Services
{
    public class WorkLogClientService : IWorkLogClientService
    {
        private readonly TimeTrackingClientSettings _settings;
        private readonly ILogger<WorkLogClientService> _logger;
        public HttpClient Client { get; }
        public WorkLogClientService(HttpClient client,
            TimeTrackingClientSettings settings)
        {
            _settings = settings;
            client.BaseAddress = new Uri(_settings.Url);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client = client;
        }

        public WorkLogClientService(ILogger<WorkLogClientService> logger)
        {
            _logger = logger;
        }
        public async Task<ApiResponse<UserActivityDto>> GetUserActivities(ReportGeneratorRequest request)
        {
            try
            {
                var nw = new NameValueCollection()
                {
                    {nameof(ReportGeneratorRequest.ProjectId), request.ProjectId.ToString()},
                    {nameof(ReportGeneratorRequest.UserId), request.UserId.ToString()},
                };
            
                var response = await Client.GetAsync(_settings+nw.ToQueryString());

                response.EnsureSuccessStatusCode();
            
                var activities =response.Content.ReadAsAsync<ApiResponse<UserActivityDto>>().Result;
                return activities;
            }
            catch (Exception e)
            {
               _logger.LogError(e, "An error occured while fetching user {0} activities {1}",
                   request.UserId,request.ProjectId);
               return ApiResponse<UserActivityDto>.InternalError();
            }
        }
    }
}