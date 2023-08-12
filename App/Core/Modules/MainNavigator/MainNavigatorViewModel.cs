using System.Reactive;
using EcoNotifications.App.Core.Common;
using EcoNotifications.App.Core.Modules.Events;
using EcoNotifications.App.Core.Modules.Requests;
using ReactiveUI;

namespace EcoNotifications.App.Core.Modules.Main;

public class MainNavigatorViewModel : BaseViewModel
{
    private BaseViewModel _currentViewModel;

    public string Title => "Домашняя страница";

    public BaseViewModel CurrentViewModel
    {
        get => _currentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    public IEnumerable<BaseViewModel> AvailableViewModels { get; }

    public ReactiveCommand<BaseViewModel, Unit> NavigateToVmCommand { get; }
    
    public MainNavigatorViewModel()
    {
        NavigateToVmCommand = ReactiveCommand.Create<BaseViewModel>(NavigateToVm);
        AvailableViewModels = new BaseViewModel[]
        {
            new AllEventsViewModel(),
            new AllRequestsViewModel()
        };
        _currentViewModel = AvailableViewModels.First();
    }

    private void NavigateToVm(BaseViewModel targetVm)
    {
        CurrentViewModel = targetVm;
    }
}