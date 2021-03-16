using System;
using System.IO;
using GemBox.Spreadsheet;
using TimeTracking.Common.Abstract;
using TimeTracking.Common.Enums;
using TimeTracking.ReportGenerator.Bl.Abstract;
using TimeTracking.ReportGenerator.Models;
using TimeTracking.ReportGenerator.Models.Responces;

namespace TimeTracking.ReportGenerator.Bl.Impl.Services
{
    public class ReportExporter : IReportExporter
    {
        private readonly IReadOnlyTemplateStorageService _readOnlyTemplateStorageService;

        public ReportExporter(IReadOnlyTemplateStorageService readOnlyTemplateStorageService)
        {
            _readOnlyTemplateStorageService = readOnlyTemplateStorageService;
        }

        public ReportExporterResponse GenerateReportForExport(UserActivityDto userActivity, ReportFormatType formatType)
        {
            // If using Professional version, put your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            var worklogs = userActivity.WorkLogItems;
            int numberOfItems =  worklogs.Count;

            var stringPath = _readOnlyTemplateStorageService.GetPathByKey(ReportType.ActivitiesReport.ToString());
            // Load an Excel template. xls
            var workbook = ExcelFile.Load(stringPath);

            // Get template sheet.
            var worksheet = workbook.Worksheets[0];

            // Find cells with placeholder text and set their values.
            int row, column;
            if (worksheet.Cells.FindText("[Name#]", out row, out column))
                worksheet.Cells[row, column].Value = userActivity.UserName;
            if (worksheet.Cells.FindText("[Surname#]", out row, out column))
                worksheet.Cells[row, column].Value =  userActivity.UserSurname;
            if (worksheet.Cells.FindText("[Project name#]", out row, out column))
                worksheet.Cells[row, column].Value = userActivity.ProjectName;
            if (worksheet.Cells.FindText("[Email#]", out row, out column))
                worksheet.Cells[row, column].Value = userActivity.UserEmail;

            // Copy template row.
            row = 17;
            worksheet.Rows.InsertCopy(row + 1, numberOfItems - 1, worksheet.Rows[row]);

            
            // Fill copied rows with sample data.
            var random = new Random();
            for (int i = 0; i < numberOfItems; i++)
            {
                var currentRow = worksheet.Rows[row + i];
                currentRow.Cells[1].SetValue(worklogs[i].StartDate.DateTime.ToLongDateString());
                currentRow.Cells[2].SetValue(worklogs[i].Description);
                currentRow.Cells[3].SetValue(worklogs[i].ActivityType.ToString());
                currentRow.Cells[4].SetValue(worklogs[i].TimeSpent.ToString(@"dd\.hh\:mm\:ss"));
            }

            worksheet.Rows[12].Cells[4].SetValue(userActivity.TotalWorkLogInSeconds);
            worksheet.Calculate();
            // Save the modified Excel template to output file.

            var saveOptions = GetFormatOptions(formatType);
            
            using var stream = new MemoryStream();
            workbook.Save(stream, saveOptions.Item2);
            return new ReportExporterResponse
            {
                FileContentType = saveOptions.Item2.ContentType,
                FileName =
                    $"Worklog_{userActivity.UserName}_{userActivity.UserSurname}_{DateTime.UtcNow}.{saveOptions.Item1.ToLower()}",
                FileBytes = stream.ToArray()
            };
        }

        private (string,SaveOptions) GetFormatOptions(ReportFormatType formatType)
        {
            switch (formatType)
            {
              case ReportFormatType.Excel:
                  return  ("xlsx",new XlsxSaveOptions());
              case ReportFormatType.Pdf:
                  return  ("pdf",new PdfSaveOptions());
              default:
                  return ("xlsx",new XlsxSaveOptions());
            }
        }
        
    }

}