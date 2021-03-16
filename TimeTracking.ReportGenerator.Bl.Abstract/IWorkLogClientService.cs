using System.Threading.Tasks;
using TimeTracking.Common.Wrapper;
using TimeTracking.ReportGenerator.Models;
using TimeTracking.ReportGenerator.Models.Requests;

namespace TimeTracking.ReportGenerator.Bl.Abstract
{
    public interface IWorkLogClientService
    {
        Task<ApiResponse<UserActivityDto>> GetUserActivities(ReportGeneratorRequest request);
    }

}