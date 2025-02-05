namespace Scheduling.Domain.Interfaces.Repositories
{
    public interface ICompanyNotificationsRepository
    {
        Models.CompanyNotifications Index(Guid index);
    }
}
