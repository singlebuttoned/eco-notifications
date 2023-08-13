using Avalonia.ReactiveUI;
using EcoNotifications.App.Core.Modules.MainNavigator;

namespace EcoNotifications.App.Front.Modules.MainNavigator;

public partial class MainNavigatorView : ReactiveUserControl<MainNavigatorViewModel>
{
    public MainNavigatorView()
    {
        InitializeComponent();
    }
}