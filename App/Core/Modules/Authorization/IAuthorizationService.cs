namespace EcoNotifications.App.Core.Modules.Authorization;

public interface IAuthorizationService
{
    Task<bool> IsAuthorized();
}