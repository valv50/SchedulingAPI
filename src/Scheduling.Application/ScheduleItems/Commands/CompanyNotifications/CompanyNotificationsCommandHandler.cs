using Scheduling.Domain.Interfaces.Handlers;
using Scheduling.Domain.Interfaces.Repositories;

namespace Scheduling.Application.ScheduleItems.Commands.CompanyNotifications
{
    public class CompanyNotificationsCommandHandler(ICompanyNotificationsRepository companyNotificationsRepository)
        : ICompanyNotificationsHandler
    {
        public Scheduling.Domain.Models.CompanyNotifications? Handle(Guid index)
        {
            var validator = new CompanyNotificationsCommandValidator(); ;

            var results = validator.Validate(index);

            if (!results.IsValid)
            {
                return null;
            }

            return companyNotificationsRepository.Index(index);
        }
    }
}
