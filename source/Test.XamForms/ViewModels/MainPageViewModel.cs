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
      NavigateToAsync(nameof(CollectionSwipeView));
    });

    public DelegateCommand CmdListViewSwipeView => new DelegateCommand(async () =>
    {
      NavigateToAsync(nameof(ListViewSwipeView));
    });

    private async void NavigateToAsync(string page)
    {
      var ret = await NavigationService.NavigateAsync(page);
      if (!ret.Success)
      {
        System.Diagnostics.Debug.WriteLine($"> Failure to navigate to, {page}");
        System.Diagnostics.Debug.WriteLine($"> {ret.Exception}");
      }

    }
  }
}