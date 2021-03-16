namespace TimeTracking.ReportGenerator.Models.Responces
{
    public class ReportExporterResponse
    {
        public  byte[] FileBytes { get; set; }
        public  string FileName { get; set; }
        public  string FileContentType { get; set; }
    }
}