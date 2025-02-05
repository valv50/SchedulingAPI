namespace Scheduling.Domain.Models
{
    public class ScheduleItem
    {
        public string? MarketName { get; set; }

        public ICollection<byte> Dates { get; set; }

        public ICollection<string> CompanyTypes { get; set; }
    }
}
