namespace Scheduling.Domain.Models;

public partial class Company
{
    public Guid CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public string? Number { get; set; }

    public Guid TypeId { get; set; }

    public Guid MarketId { get; set; }

    public virtual Models.Market Market { get; set; } = null!;

    public virtual Models.CompanyType Type { get; set; } = null!;
}
