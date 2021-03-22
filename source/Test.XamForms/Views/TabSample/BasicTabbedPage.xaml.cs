using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Test.XamForms.Client.Views.TabSample
{
  public partial class BasicTabbedPage : Xamarin.Forms.TabbedPage
  {
    public BasicTabbedPage()
    {
      InitializeComponent();

      On<Xamarin.Forms.PlatformConfiguration.Android>()
        .SetToolbarPlacement(ToolbarPlacement.Bottom);
    }
  }
}
