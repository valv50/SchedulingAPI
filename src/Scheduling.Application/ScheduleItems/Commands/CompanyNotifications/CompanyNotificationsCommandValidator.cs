using FluentValidation;

namespace Scheduling.Application.ScheduleItems.Commands.CompanyNotifications
{
    public class CompanyNotificationsCommandValidator : AbstractValidator<Guid>
    {
        public CompanyNotificationsCommandValidator() 
        {
            RuleFor(r => r).NotEmpty();
        }
    }
}
