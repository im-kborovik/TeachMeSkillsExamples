namespace Module25_LINQ.Data.Entities;

public class Product
{
    public string Email { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"{nameof(Email)}: {Email}; {nameof(Name)}: {Name}; {nameof(Price)}: {Price}";
    }
}