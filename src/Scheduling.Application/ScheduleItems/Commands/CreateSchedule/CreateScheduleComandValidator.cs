using FluentValidation;
using Scheduling.Domain.Constants;
using Scheduling.Domain.Models;

namespace Scheduling.Application.ScheduleItems.Commands.CreateSchedule
{
    public class CreateScheduleComandValidator : AbstractValidator<ScheduleItem>
    {
        private readonly List<string> validCompanyTypes = 
            [CompanyTypes.Small, CompanyTypes.Medium, CompanyTypes.Large];

        public CreateScheduleComandValidator() 
        {
            RuleFor(dto => dto.MarketName)
                .Length(2, 100);

            RuleForEach(dto => dto.CompanyTypes)
                .Must(validCompanyTypes.Contains)
                .WithMessage(ScheduleComand.InvalidType);

            RuleFor(dto => dto.Dates)                
                .NotEmpty();
        }
    }
}
