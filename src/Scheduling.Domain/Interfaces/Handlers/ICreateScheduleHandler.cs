namespace Scheduling.Domain.Interfaces.Handlers
{
    public interface ICreateScheduleHandler
    {
        public bool Handle(Domain.Models.ScheduleItem scheduleItem);
    }
}
