using Prism.Commands;
using Prism.Navigation;
using Test.XamForms.Client.Views;
using Test.XamForms.Client.Views.TabSample;

namespace Test.XamForms.Client.ViewModels
{
  public class MainPageViewModel : ViewModelBase
  {
    public MainPageViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Choose Sample";
    }

    public DelegateCommand CmdCollectionSwipeView => new DelegateCommand(() =>
    {
      NavigateToAsync(nameof(CollectionSwipeView));
    });

    public DelegateCommand CmdListViewSwipeView => new DelegateCommand(() =>
    {
      NavigateToAsync(nameof(ListViewSwipeView));
    });

    public DelegateCommand CmdBasicTabs => new DelegateCommand(() =>
    {
      NavigateToAsync(nameof(BasicTabbedPage));
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