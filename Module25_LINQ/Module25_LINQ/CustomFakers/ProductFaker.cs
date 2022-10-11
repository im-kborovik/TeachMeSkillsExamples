using Bogus;
using Module25_LINQ.Data.Entities;

namespace Module25_LINQ.CustomFakers;

public sealed class ProductFaker : Faker<Product>
{
    public ProductFaker(string email)
    {
        RuleFor(q => q.Email, email);
        RuleFor(q => q.Name, q => q.Commerce.ProductName());
        RuleFor(q => q.Price, q => q.Commerce.Price());
    }
}