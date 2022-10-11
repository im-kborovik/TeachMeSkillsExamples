namespace Module25_LINQ.Data.Entities;

public class Address
{
    public string Country { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string ZipCode { get; set; }

    public override string ToString()
    {
        return $"{nameof(Country)}: {Country}; {nameof(City)}: {City}; "
               + $"{nameof(Street)}: {Street}; {nameof(ZipCode)}: {ZipCode}";
    }
}