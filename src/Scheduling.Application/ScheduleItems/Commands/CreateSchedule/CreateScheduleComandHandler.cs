using Scheduling.Domain.Interfaces.Handlers;
using Scheduling.Domain.Interfaces.Repositories;

namespace Scheduling.Application.ScheduleItems.Commands.CreateSchedule
{
    public class CreateScheduleComandHandler(IScheduleRepository scheduleRepository)
        : ICreateScheduleHandler
    {
        public bool Handle(Domain.Models.ScheduleItem scheduleItem)
        {
            var validator = new CreateScheduleComandValidator();

            var results = validator.Validate(scheduleItem);

            if (!results.IsValid)
            {
                return false;
            }

            return scheduleRepository.Create(scheduleItem);
        }
    }
}
