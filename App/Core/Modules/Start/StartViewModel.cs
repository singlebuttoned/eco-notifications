using System.Reactive;
using System.Reactive.Linq;
using AsyncAwaitBestPractices;
using EcoNotifications.App.Core.Common;
using EcoNotifications.App.Core.Modules.Authorization;
using EcoNotifications.App.Core.Modules.MainNavigator;
using ReactiveUI;

namespace EcoNotifications.App.Core.Modules.Start;

public class StartViewModel : BaseViewModel
{
    private readonly IAuthorizationService _authorizationService;
    private bool _isLoading;
    private bool _isError;
    private readonly StartParameter _parameter;

    public Interaction<Unit, Unit> Authorize { get; } = new();
    
    public ReactiveCommand<Unit, MainNavigatorViewModel> GoToMain { get; }
    
    public ReactiveCommand<Unit, Unit> GoByUrl { get; }
    
    public ReactiveCommand<Unit, Unit> GoByQr { get; }

    public bool IsError
    {
        get => _isError;
        set => this.RaiseAndSetIfChanged(ref _isError, value);
    }

    public bool IsLoading
    {
        get => _isLoading;
        set => this.RaiseAndSetIfChanged(ref _isLoading, value);
    }

    public StartViewModel(IAuthorizationService authorizationService, StartParameter parameter)
    {
        _parameter = parameter;
        _authorizationService = authorizationService;
        
        GoToMain = ReactiveCommand.CreateFromObservable(() =>
        {
            return Observable.Return(new MainNavigatorViewModel());
        });
        GoByUrl = ReactiveCommand.CreateFromTask(_ => Task.FromResult(Unit.Default));
        GoByQr = ReactiveCommand.CreateFromTask(_ => Task.FromResult(Unit.Default));
    }
    
    public async Task StartApp()
    {
        IsLoading = true;
        
        var isAuthorized = await _authorizationService.IsAuthorized();
        if (isAuthorized)
        {
            Proceed();
        }
        else
        {
            await Authorize.Handle(Unit.Default);
            isAuthorized = await _authorizationService.IsAuthorized();
            if (isAuthorized)
                Proceed();
            else
                IsError = true;
        }
        
        IsLoading = false;
    }

    private void Proceed()
    {

        if (_parameter is { FromQrParameter: not null, FromUrlParameter: not null })
            throw new ArgumentException("Only one parameter can be set");

        if (_parameter.FromQrParameter != null)
            GoByQr.Execute();
        else if (_parameter.FromUrlParameter != null)
            GoByUrl.Execute();
        else
            GoToMain.Execute().Subscribe();
    }
}