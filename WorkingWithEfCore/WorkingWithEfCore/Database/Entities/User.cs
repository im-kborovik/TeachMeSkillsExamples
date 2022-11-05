namespace WorkingWithEfCore.Database.Entities;

public class User
{
    public int UserId { get; set; }

    public int? CompanyId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public int? YearsUntilRetirement { get; set; }

    public ICollection<Address> Addresses { get; set; }

    public Contact Contact { get; set; }

    public Company Company { get; set; }
}