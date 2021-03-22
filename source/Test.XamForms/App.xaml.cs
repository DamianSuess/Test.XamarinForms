using Prism;
using Prism.Ioc;
using Test.XamForms.Client.Services;
using Test.XamForms.Client.ViewModels;
using Test.XamForms.Client.Views;
using Test.XamForms.Client.Views.TabSample;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Test.XamForms.Client
{
  public partial class App
  {
    public App(IPlatformInitializer initializer)
      : base(initializer)
    {
    }

    protected override async void OnInitialized()
    {
      InitializeComponent();

      // Before Xamarin.Forms v5.0 you must include:
      ////Device.SetFlags(new string[]
      ////{
      ////  "SwipeView_Experimental",
      ////  "CarouselView_Experimental"
      ////});

      var ret = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
      if (!ret.Success)
      {
        System.Diagnostics.Debug.WriteLine("> Failure to navigate to start page");
        System.Diagnostics.Debug.WriteLine($"> {ret.Exception}");
      }
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
      containerRegistry.RegisterSingleton<ILogService, LogService>();

      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
      containerRegistry.RegisterForNavigation<CollectionSwipeView, CollectionSwipeViewModel>();
      containerRegistry.RegisterForNavigation<ShakeBehaviorsView, ShakeBehaviorsViewModel>();
      containerRegistry.RegisterForNavigation<ListViewSwipeView, ListViewSwipeViewModel>();
      containerRegistry.RegisterForNavigation<BasicTabbedPage, BasicTabbedPageViewModel>();
      containerRegistry.RegisterForNavigation<BasicTab1View, BasicTab1ViewModel>();
      containerRegistry.RegisterForNavigation<BasicTab2View, BasicTab2ViewModel>();
      containerRegistry.RegisterForNavigation<BasicTab3View, BasicTab3ViewModel>();
    }
  }
}