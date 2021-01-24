/* CollectionView with SwipeView Sample
 *
 * Updating ObservableCollection
 *  - The RaisePropertyChanged will handle Adding and Removing items well, but not updating.
 *  - In order to have the item's text updated, your object (Customer) can inherit
 *    from the both your Interface (ICustomer) and INotifyableProperty as well.
 */

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Prism.Commands;
using Prism.Navigation;
using Test.XamForms.Client.Models;
using Test.XamForms.Client.Services;

namespace Test.XamForms.Client.ViewModels
{
  public class CollectionSwipeViewModel : ViewModelBase
  {
    private ObservableCollection<CustomerNotifyable> _customers;

    public CollectionSwipeViewModel(INavigationService navigationService, ILogService logService)
      : base(navigationService)
    {
      _log = logService;
      Customers = new ObservableCollection<CustomerNotifyable>();
      //// Customers.CollectionChanged += OnCustomersCollectionChanged;

      InitSample();
    }

    private ILogService _log;

    public ObservableCollection<CustomerNotifyable> Customers
    {
      get => _customers;
      set => SetProperty(ref _customers, value);
    }

    public DelegateCommand CmdItemAdd => new DelegateCommand(OnItemAdd);

    public DelegateCommand<CustomerNotifyable> CmdItemEdit => new DelegateCommand<CustomerNotifyable>(OnItemEdit);

    public DelegateCommand<CustomerNotifyable> CmdItemRemove => new DelegateCommand<CustomerNotifyable>((c) =>
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

    private void OnItemEdit(CustomerNotifyable customer)
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

    private void OnCustomersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        _log.Debug("Item Added");
        ////foreach (Customer item in e.NewItems)
        ////  item.PropertyChanged += this.OnItemPropertyChanged;
      }
      else if (e.Action == NotifyCollectionChangedAction.Remove)
      {
        _log.Debug("Item Removed");

        ////foreach (Customer item in e.NewItems)
        ////  item.PropertyChanged -= this.OnItemPropertyChanged;
      }
      else if (e.Action == NotifyCollectionChangedAction.Replace)
      {
        _log.Debug("Item Replaced");
      }
    }

    private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      ////this.PhotosIHate.Refresh();
      ////this.PhotosILike.Refresh();
    }
  }
}