namespace EcoNotifications.App.Core.Modules.Authorization;

public class AuthorizationService : IAuthorizationService
{
    private readonly Queue<bool> _queue = new(new []{false, true});
    public Task<bool> IsAuthorized() => Task.FromResult(_queue.Dequeue());
}