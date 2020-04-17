namespace DailyReports.Contracts.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StationCode { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
    }
}