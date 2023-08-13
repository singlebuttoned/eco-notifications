using System;
using System.Data;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using EcoNotifications.App.Core.Modules.Authorization;
using EcoNotifications.App.Core.Modules.MainNavigator;
using EcoNotifications.App.Core.Modules.Start;
using EcoNotifications.App.Front.Modules.MainNavigator;
using ReactiveUI;

namespace EcoNotifications.App.Front.Modules.Start;

public partial class StartView : ReactiveUserControl<StartViewModel>
{
    public StartView(StartParameter parameter)
    {
        ViewModel = new StartViewModel(new AuthorizationService(), parameter);

        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            if (ViewModel == null) 
                throw new NoNullAllowedException();
            
            ViewModel?.Authorize.RegisterHandler(PerformAuthInteraction).DisposeWith(disposables);
            ViewModel?.GoToMain
                .Subscribe(GoToMain)
                .DisposeWith(disposables);
            ViewModel?.GoByUrl
                .Subscribe(_ => { })
                .DisposeWith(disposables);
            ViewModel?.GoByQr.Subscribe(_ => { }).DisposeWith(disposables);
            
            ViewModel?.StartApp().SafeFireAndForget();
        });
    }

    private void GoToMain(MainNavigatorViewModel vm)
    {
        var window = VisualRoot as Window ?? throw new NoNullAllowedException();
        window.Content = new MainNavigatorView { ViewModel = vm };
    }

    private async Task PerformAuthInteraction(InteractionContext<Unit, Unit> interaction)
    {
        Console.WriteLine("Authorize");
        await Task.Delay(1000);
        Console.WriteLine("Authorize done");
        
        interaction.SetOutput(Unit.Default);
    }
}