using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EcoNotifications.App.Core.Modules.MainNavigator;
using EcoNotifications.App.Front.Modules.MainNavigator;
using MainWindow = EcoNotifications.App.Front.Modules.Start.MainWindow;

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
            desktop.MainWindow = new MainWindow(new ());
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            singleViewPlatform.MainView = new MainWindow(new ());

        base.OnFrameworkInitializationCompleted();
    }
}