using Microsoft.EntityFrameworkCore;
using Scheduling.Domain.Interfaces.Repositories;
using Scheduling.Infrastructure.Persistence;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Scheduling.Infrastructure.Repositories
{
    public class CompanyNotificationsRepository(SchedulingContext dbContext)
        : ICompanyNotificationsRepository
    {
        public Domain.Models.CompanyNotifications Index(Guid index)
        {
            if (index == Guid.Empty)
            {
                return null;
            }

            string sqlStatement = $@"SELECT * FROM dbo.fn_GetNotifications ('{index.ToString()}', GETDATE())";

            var query = FormattableStringFactory.Create(sqlStatement);

            var notifications =
               dbContext.Notifications.FromSqlRaw(sqlStatement)
               .ToList();

            var result = new Domain.Models.CompanyNotifications()
            {
                CompanyId = index
                ,
                Notifications = notifications.Select(s => s.DateData.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList()
            };

            return result;
        }
    }
}
