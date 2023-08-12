using EcoNotifications.App.Core.Common;
using EcoNotifications.App.Core.Modules.MainNavigator;
using EcoNotifications.App.Core.Resources;

namespace EcoNotifications.App.Core.Modules.Events;

public class AllEventsViewModel : INavigatorItemViewModel
{
    public string Title => "События";
    
    public Icon Icon => Icon.AllEventsNavigatorItem;
}