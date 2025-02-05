using Scheduling.Domain.Models;

namespace Scheduling.Domain.Interfaces.Repositories
{
    public interface IScheduleRepository
    {
        bool Create(ScheduleItem scheduleItem);
    }
}
