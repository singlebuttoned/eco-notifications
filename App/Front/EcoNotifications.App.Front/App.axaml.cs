using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EcoNotifications.App.Core.Modules.Main;
using EcoNotifications.App.Front.Modules.MainNavigator;
using EcoNotifications.App.Front.Views;

namespace EcoNotifications.App.Front;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = new MainNavigatorWindow
            {
                DataContext = new MainNavigatorViewModel()
            };
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            singleViewPlatform.MainView = new MainNavigatorView
            {
                DataContext = new MainNavigatorViewModel()
            };

        base.OnFrameworkInitializationCompleted();
    }
}