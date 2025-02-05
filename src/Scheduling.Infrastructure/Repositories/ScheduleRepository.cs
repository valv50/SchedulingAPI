using Scheduling.Domain.Interfaces.Repositories;
using Scheduling.Domain.Models;
using Scheduling.Infrastructure.Persistence;

namespace Scheduling.Infrastructure.Repositories
{
    internal class ScheduleRepository(SchedulingContext dbContext)
        : IScheduleRepository
    {
        public bool Create(ScheduleItem scheduleItem)
        {
            var created = false;

            using var transaction = dbContext.Database.BeginTransaction();
            {
                try
                {
                    var marketId = dbContext.Markets
                        .Where(w => w.MarketName == scheduleItem.MarketName)
                        .Select(s => s.MarketId)
                        .FirstOrDefault();

                    if (marketId == null)
                    {
                        marketId = Guid.NewGuid();

                        var market = new Domain.Models.Market
                        {
                            MarketId = marketId,
                            MarketName = scheduleItem.MarketName
                        };

                        dbContext.Markets.Add(market);

                        dbContext.SaveChanges();
                    }

                    var schedule = new Domain.Models.Schedule()
                    {
                        ScheduleId = Guid.NewGuid(),
                        ScheduleName = scheduleItem.MarketName,
                        MarketId = marketId
                    };

                    dbContext.Schedules.Add(schedule);
                    dbContext.SaveChanges();

                    foreach (var date in scheduleItem.Dates)
                    {
                        var scheduleDate = new Domain.Models.ScheduleDate()
                        {
                            ScheduleDateId = Guid.NewGuid(),
                            ScheduleId = schedule.ScheduleId,
                            Date = date
                        };

                        dbContext.ScheduleDates.Add(scheduleDate);
                        dbContext.SaveChanges();
                    }

                    foreach (var companyType in scheduleItem.CompanyTypes)
                    {
                        var typeId = dbContext.CompanyTypes
                            .Where(w => w.TypeName == companyType)
                            .Select(s => s.TypeId)
                            .FirstOrDefault();

                        if (typeId == null)
                        {
                            typeId = Guid.NewGuid();

                            var newCompanyType = new Domain.Models.CompanyType()
                            {
                                TypeId = typeId,
                                TypeName = companyType
                            };

                            dbContext.CompanyTypes.Add(newCompanyType);

                            dbContext.SaveChanges();
                        }

                        var scheduleType = new Domain.Models.ScheduleType()
                        {
                            ScheduleTypeId = Guid.NewGuid(),
                            ScheduleId = schedule.ScheduleId,
                            TypeId = typeId
                        };

                        dbContext.ScheduleTypes.Add(scheduleType);
                        dbContext.SaveChanges();
                    }

                    transaction.Commit();

                    created = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    created = false;
                }
            }

            return created;
        }
    }
}
