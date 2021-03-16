using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeTracking.ReportGenerator.Bl.Abstract;
using TimeTracking.ReportGenerator.Models;

namespace TimeTracking.ReportGenerator.WebApi.Controllers
{
    [Authorize]
    public class ReportController:ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Generates report by config
        /// </summary>
        /// <param name="reportConfiguration"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<FileContentResult> GenerateReport([FromRoute]ReportConfiguration reportConfiguration)
        {
            var response = await _reportService.GenerateReportAsync(reportConfiguration);
            return new FileContentResult(response.Data.FileBytes, response.Data.FileContentType)
            {
                FileDownloadName = response.Data.FileName,
            };
        }
    }
}