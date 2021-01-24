using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Test.XamForms.Client.Models
{
  public class CustomerNotifyable : ICustomer, INotifyPropertyChanged
  {
    private string _name = string.Empty;

    public CustomerNotifyable()
    {
      Id = default(System.Guid).ToString();
    }

    public CustomerNotifyable(string id, string name)
    {
      Id = id;
      Name = name;
    }

    public string Id { get; set; }

    public string Name
    {
      get => _name;
      set
      {
        if (_name == value)
          return;

        _name = value;
        OnPropertyChanged();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}