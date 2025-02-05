namespace Scheduling.Domain.Interfaces.Handlers
{
    public interface ICompanyNotificationsHandler
    {
        public Models.CompanyNotifications Handle(Guid companyId);
    }
}

