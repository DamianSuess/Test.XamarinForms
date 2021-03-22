using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Test.XamForms.Client.ViewModels
{
  public class BasicTab1ViewModel : ViewModelBase
  {
    public BasicTab1ViewModel(INavigationService navigationService) : base(navigationService)
    {
      Title = "Tab 1";
    }
  }
}
