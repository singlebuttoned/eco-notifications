using System.Reactive;
using EcoNotifications.App.Core.Common;
using EcoNotifications.App.Core.Modules.Events;
using EcoNotifications.App.Core.Modules.Requests;
using ReactiveUI;

namespace EcoNotifications.App.Core.Modules.MainNavigator;

public class MainNavigatorViewModel : BaseViewModel
{
    private INavigatorItemViewModel _currentViewModel;

    public string Title => "Домашняя страница";

    public INavigatorItemViewModel CurrentViewModel
    {
        get => _currentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    public IEnumerable<INavigatorItemViewModel> AvailableViewModels { get; }

    public ReactiveCommand<INavigatorItemViewModel, Unit> NavigateToVmCommand { get; }
    
    public MainNavigatorViewModel()
    {
        NavigateToVmCommand = ReactiveCommand.Create<INavigatorItemViewModel>(NavigateToVm);
        AvailableViewModels = new List<INavigatorItemViewModel>()
        {
            new AllEventsViewModel(),
            new AllRequestsViewModel()
        };
        _currentViewModel = AvailableViewModels.First();
    }

    private void NavigateToVm(INavigatorItemViewModel targetVm)
    {
        CurrentViewModel = targetVm;
    }
}