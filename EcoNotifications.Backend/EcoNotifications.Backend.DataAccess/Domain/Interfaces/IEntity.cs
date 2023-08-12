namespace EcoNotifications.Backend.DataAccess.Domain.Interfaces;

public interface IGuidEntity
{
    Guid? Id { get; set; }
}

public interface IAuditedEntity : IGuidEntity
{
    string? CreatedBy { get; set; }
    string? ModifiedBy { get; set; }
}

public interface ITimedEntity : IAuditedEntity
{
    DateTime? CreatedOn { get; set; }
    DateTime? ModifiedOn { get; set; }
}

public interface IHistoricalEntity
{
    bool IsDeleted { get; set; }
}

public interface IEntity : ITimedEntity, IHistoricalEntity
{
}
