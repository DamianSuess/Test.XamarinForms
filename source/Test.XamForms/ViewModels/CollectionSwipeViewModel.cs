using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Test.XamForms.Client.ViewModels
{
  public class CollectionSwipeViewModel : ViewModelBase
  {
    public CollectionSwipeViewModel(INavigationService navigationService)
      : base(navigationService)
    {

    }
  }
}
