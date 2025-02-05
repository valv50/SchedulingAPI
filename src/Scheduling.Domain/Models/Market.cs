namespace Scheduling.Domain.Models;

public partial class Market
{
    public Guid MarketId { get; set; }

    public string? MarketName { get; set; }

    public virtual ICollection<Models.Schedule> Schedules { get; set; } = new List<Models.Schedule>();
}
