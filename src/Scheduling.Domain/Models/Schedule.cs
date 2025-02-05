namespace Scheduling.Domain.Models;

public partial class Schedule
{
    public Guid ScheduleId { get; set; }

    public string? ScheduleName { get; set; }

    public Guid MarketId { get; set; }

    public DateOnly CreationDate { get; set; }

    public virtual Scheduling.Domain.Models.Market Market { get; set; } = null!;

    public virtual ICollection<Models.ScheduleDate> ScheduleDates { get; set; } = new List<Models.ScheduleDate>();

    public virtual ICollection<Models.ScheduleType> ScheduleTypes { get; set; } = new List<Models.ScheduleType>();
}
