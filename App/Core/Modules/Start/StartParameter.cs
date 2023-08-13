using EcoNotifications.App.Core.Records;

namespace EcoNotifications.App.Core.Modules.Start;

public record StartParameter()
{
    public FromQrParameter? FromQrParameter { get; init; }
    
    public FromUrlParameter? FromUrlParameter { get; init; }
}

public record FromQrParameter()
{
    public Id Id { get; init; }
    public Geo Geo { get; init; }
}

public record FromUrlParameter()
{
}