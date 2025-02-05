using FluentValidation.TestHelper;
using Xunit;

namespace Scheduling.Application.ScheduleItems.Commands.CompanyNotifications.Tests
{
    public class CompanyNotificationsCommandValidatorTests
    {
        [Fact()]
        public void CompanyNotificationsCommandValidator_ForValidCommand_NoErrors()
        {

            //arrange
            var companyId = Guid.NewGuid();

            var validator = new CompanyNotificationsCommandValidator();

            //act
            var result = validator.TestValidate(companyId);

            //assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void CompanyNotificationsCommandValidator_ForInValidCommand_Errors()
        {

            //arrange
            var companyId = Guid.Empty;

            var validator = new CompanyNotificationsCommandValidator();

            //act
            var result = validator.TestValidate(companyId);

            //assert
            result.ShouldHaveAnyValidationError();
        }
    }
}