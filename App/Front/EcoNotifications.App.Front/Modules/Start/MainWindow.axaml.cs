using System.Net;
using Avalonia.Controls;
using EcoNotifications.App.Core.Modules.Authorization;
using EcoNotifications.App.Core.Modules.Start;

namespace EcoNotifications.App.Front.Modules.Start;

public partial class MainWindow : Window
{
    public MainWindow(StartParameter parameter)
    {
        InitializeComponent();
        Content = new StartView(parameter);
    }
}