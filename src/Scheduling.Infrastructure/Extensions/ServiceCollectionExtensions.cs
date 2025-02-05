using Microsoft.EntityFrameworkCore;
using Scheduling.Application.ScheduleItems.Commands.CompanyNotifications;
using Scheduling.Application.ScheduleItems.Commands.CreateSchedule;
using Scheduling.Domain.Interfaces.Handlers;
using Scheduling.Domain.Interfaces.Repositories;
using Scheduling.Infrastructure.Persistence;
using Scheduling.Infrastructure.Repositories;

namespace Scheduling.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SchedulingDB");

            services.AddDbContext<SchedulingContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            services.AddScoped<ICompanyNotificationsRepository, CompanyNotificationsRepository>();

            services.AddScoped<ICreateScheduleHandler, CreateScheduleComandHandler>();

            services.AddScoped<ICompanyNotificationsHandler, CompanyNotificationsCommandHandler>();
        }
    }
}
