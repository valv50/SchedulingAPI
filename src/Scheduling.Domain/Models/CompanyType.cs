namespace Scheduling.Domain.Models;

public partial class CompanyType
{
    public Guid TypeId { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Models.ScheduleType> ScheduleTypes { get; set; } = new List<Models.ScheduleType>();
}
