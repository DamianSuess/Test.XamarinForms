/* CollectionView with SwipeView Sample
 *
 * Updating ObservableCollection
 *  - The RaisePropertyChanged will handle Adding and Removing items well, but not updating.
 *  - In order to have the item's text updated, your object (Customer) can inherit
 *    from the both your Interface (ICustomer) and INotifyableProperty as well.
 *    Pro Tip:
 *      The use of the 'ICustomer' interface inside of ObservableCollection is no
 *      mistake. It's good practice to utilize your base class.
 */

using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation;
using Test.XamForms.Client.Models;
using Test.XamForms.Client.Services;

namespace Test.XamForms.Client.ViewModels
{
  public class CollectionSwipeViewModel : ViewModelBase
  {
    private ObservableCollection<ICustomer> _customers;

    public CollectionSwipeViewModel(INavigationService navigationService, ILogService logService)
      : base(navigationService)
    {
      _log = logService;
      Customers = new ObservableCollection<ICustomer>();
      InitSample();
    }

    private ILogService _log;

    public ObservableCollection<ICustomer> Customers
    {
      get => _customers;
      set => SetProperty(ref _customers, value);
    }

    public DelegateCommand CmdItemAdd => new DelegateCommand(OnItemAdd);

    public DelegateCommand<ICustomer> CmdItemEdit => new DelegateCommand<ICustomer>(OnItemEdit);

    public DelegateCommand<ICustomer> CmdItemRemove => new DelegateCommand<ICustomer>((c) =>
    {
      _log.Debug($"Selected remove item, '{c.Name}'");
      Customers.Remove(c);
    });

    private void OnItemAdd()
    {
      string id = (Customers.Count + 1).ToString();
      string name = "NewName-" + id;
      Customers.Add(new CustomerNotifyable(id, name));

      RaisePropertyChanged(nameof(Customers));
    }

    private void OnItemEdit(ICustomer customer)
    {
      string name = customer.Name;
      _log.Debug("Selected item to edit, Name=" + name);

      // Get the index and update it
      var ndx = Customers.IndexOf(customer);
      Customers[ndx].Name = name + "*";

      RaisePropertyChanged(nameof(Customers));
    }

    private void InitSample()
    {
      Customers.Add(new CustomerNotifyable("1", "Betty Boop"));
      Customers.Add(new CustomerNotifyable("2", "Sandy Smith"));
      Customers.Add(new CustomerNotifyable("3", "Roxie Road"));
    }
  }
}