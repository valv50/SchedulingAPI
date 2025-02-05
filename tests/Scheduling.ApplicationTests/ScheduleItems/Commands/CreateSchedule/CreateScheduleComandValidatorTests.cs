using FluentValidation.TestHelper;
using Scheduling.Domain.Models;
using Xunit;

namespace Scheduling.Application.ScheduleItems.Commands.CreateSchedule.Tests
{
    public class CreateScheduleComandValidatorTests
    {
        [Fact()]
        public void CreateScheduleComandValidator_ForValidCommand_NoErrors()
        {
            //arrange
            var scheduleItem = new ScheduleItem()
            {
                MarketName = "Norway",
                Dates = new List<byte> { 7, 14, 21, 28 },
                CompanyTypes = new List<string> { "small", "large" }
            };

            var validator = new CreateScheduleComandValidator();

            //act
            var result = validator.TestValidate(scheduleItem);

            //assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void CreateScheduleComandValidator_ForInValidCommand_Error_1()
        {
            //arrange
            var scheduleItem = new ScheduleItem()
            {
                MarketName = "N",
                Dates = new List<byte> { 7, 14, 21, 28 },
                CompanyTypes = new List<string> { "small", "large" }
            };

            var validator = new CreateScheduleComandValidator();

            //act
            var result = validator.TestValidate(scheduleItem);

            //assert
            result.ShouldHaveAnyValidationError();
        }

        [Fact()]
        public void CreateScheduleComandValidator_ForInValidCommand_Error_2()
        {
            //arrange
            var scheduleItem = new ScheduleItem()
            {
                MarketName = "Norway",
                Dates = new List<byte> { 7, 14, 21, 28 },
                CompanyTypes = new List<string> { "small", "larg" }
            };

            var validator = new CreateScheduleComandValidator();

            //act
            var result = validator.TestValidate(scheduleItem);

            //assert
            result.ShouldHaveAnyValidationError();
        }

        [Fact()]
        public void CreateScheduleComandValidator_ForInValidCommand_Error_3()
        {
            //arrange
            var scheduleItem = new ScheduleItem()
            {
                MarketName = "Norway",
                CompanyTypes = new List<string> { "small", "large" }
            };

            var validator = new CreateScheduleComandValidator();

            //act
            var result = validator.TestValidate(scheduleItem);

            //assert
            result.ShouldHaveAnyValidationError();
        }
    }
}