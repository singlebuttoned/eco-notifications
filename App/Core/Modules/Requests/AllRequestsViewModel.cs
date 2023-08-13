using EcoNotifications.App.Core.Modules.MainNavigator;
using EcoNotifications.App.Core.Resources;

namespace EcoNotifications.App.Core.Modules.Requests;

public class AllRequestsViewModel : INavigatorItemViewModel
{
    public string Title => "Обращения";
    public Icon Icon => Icon.AllRequestsNavigatorItem;
}