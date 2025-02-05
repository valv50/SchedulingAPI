namespace Scheduling.Domain.Models;

public partial class ScheduleDate
{
    public Guid ScheduleDateId { get; set; }

    public Guid ScheduleId { get; set; }

    public byte Date { get; set; }

    public virtual Scheduling.Domain.Models.Schedule Schedule { get; set; } = null!;
}
