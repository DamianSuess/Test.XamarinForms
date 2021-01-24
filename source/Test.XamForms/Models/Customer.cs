namespace Test.XamForms.Client.Models
{
  public class Customer : ICustomer
  {
    public Customer()
    {
      Id = default(System.Guid).ToString();
    }

    public Customer(string id, string name)
    {
      Id = id;
      Name = name;
    }

    public string Id { get; set; }

    public string Name { get; set; }
  }
}