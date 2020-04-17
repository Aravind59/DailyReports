namespace DailyReports.Contracts.Models
{
   public class ValidationMessage
    {
        public string Field { get; set; }
        public string ValidationMessaage { get; set; }
        public MessageTypeEnum ValidationMessageType { get; set; }

        public override string ToString()
        {
            return ValidationMessageType + ":" + ValidationMessaage;
        }
    }
}
