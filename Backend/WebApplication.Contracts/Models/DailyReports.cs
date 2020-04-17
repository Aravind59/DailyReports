using System;

namespace DailyReports.Contracts.Models
{
    public class DailyReports
    { 
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string LogNumber { get; set; }
        public float Quantity { get; set; }
        public double? Percentage { get; set; }
        public double? Price { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}