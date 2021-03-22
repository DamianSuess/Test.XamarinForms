using Prism;
using Prism.Ioc;

namespace Test.XamForms.UWP
{
  public sealed partial class MainPage
  {
    public MainPage()
    {
      this.InitializeComponent();

      // Cache Location
      System.Diagnostics.Debug.Print("Cache Location:");
      System.Diagnostics.Debug.Print(Windows.Storage.ApplicationData.Current.LocalCacheFolder.Path);

      LoadApplication(new Test.XamForms.Client.App(new UwpInitializer()));
    }
  }

  public class UwpInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register any platform specific implementations
    }
  }
}