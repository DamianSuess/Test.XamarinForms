using Prism.Commands;
using Prism.Navigation;
using Test.XamForms.Client.Views;

namespace Test.XamForms.Client.ViewModels
{
  public class MainPageViewModel : ViewModelBase
  {
    public MainPageViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Choose Sample";
    }

    public DelegateCommand CmdCollectionSwipeView => new DelegateCommand(async () =>
    {
      await NavigationService.NavigateAsync(nameof(CollectionSwipeView));
    });

    public DelegateCommand CmdListViewSwipeView => new DelegateCommand(async () =>
    {
      await NavigationService.NavigateAsync(nameof(ListViewSwipeView));
    });
  }
}