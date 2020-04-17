namespace DailyReports.Contracts.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public int? UserId { get; set; }
        public string LogNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
    }
}