namespace Scheduling.Domain.Models;

public partial class ScheduleType
{
    public Guid ScheduleTypeId { get; set; }

    public Guid ScheduleId { get; set; }

    public Guid TypeId { get; set; }

    public virtual Scheduling.Domain.Models.Schedule Schedule { get; set; } = null!;

    public virtual Scheduling.Domain.Models.CompanyType Type { get; set; } = null!;
}
