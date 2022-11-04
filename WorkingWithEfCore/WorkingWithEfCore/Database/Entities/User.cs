namespace WorkingWithEfCore.Database.Entities;

public class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public ICollection<Address> Addresses { get; set; }
}