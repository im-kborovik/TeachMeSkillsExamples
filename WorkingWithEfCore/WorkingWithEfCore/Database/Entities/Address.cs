namespace WorkingWithEfCore.Database.Entities;

public class Address
{
    public int AddressId { get; set; }

    public int UserId { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public User User { get; set; }
}