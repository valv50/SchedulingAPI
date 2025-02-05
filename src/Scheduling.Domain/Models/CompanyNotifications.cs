namespace Scheduling.Domain.Models
{
    public class CompanyNotifications
    {
        public Guid CompanyId { get; set; }

        public List<string> Notifications { get; set; } = new List<string>();
    }
}
