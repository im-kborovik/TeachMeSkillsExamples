using Bogus;
using Module25_LINQ.CustomFakers;
using Module25_LINQ.Data.Entities;

namespace Module25_LINQ.Data;

public class DataStorage : IDataStorage
{
    private static readonly Dictionary<string, User> Users = new();

    private static readonly List<Product> Products = new();

    static DataStorage()
    {
        InitUsers();
        InitProducts();
    }

    public IReadOnlyCollection<User> GetUsers()
    {
        return Users.Values;
    }

    public IReadOnlyCollection<Product> GetProducts()
    {
        return Products;
    }

    public string AddRandomUser()
    {
        var randomUser = CreateUser();
        AddUser(randomUser);

        return randomUser.Email;
    }

    public static Address CreateAddress()
    {
        var faker = new Faker();
        return new Address
               {
                   Country = faker.Address.Country(),
                   City = faker.Address.City(),
                   Street = faker.Address.StreetAddress(),
                   ZipCode = faker.Address.ZipCode()
               };
    }

    private static User CreateUser()
    {
        var faker = new Faker();
        return new User
               {
                   Email = faker.Person.Email,
                   FirstName = faker.Person.FirstName,
                   LastName = faker.Person.LastName,
                   BirthDate = faker.Person.DateOfBirth,
                   Address = CreateAddress()
               };
    }

    private static void InitUsers()
    {
        var faker = new Faker();
        for (var i = 0; i < faker.Random.Int(3, 5); i++)
        {
            var user = CreateUser();
            AddUser(user);
        }
    }

    private static void InitProducts()
    {
        var faker = new Faker();
        foreach (var (_, user) in Users)
        {
            var productFaker = new ProductFaker(user.Email);
            var generatingProductsCount = faker.Random.Int(1, 3);
            var products = productFaker.Generate(generatingProductsCount);
            Products.AddRange(products);
        }
    }

    private static void AddUser(User user)
    {
        if (Users.ContainsKey(user.Email))
        {
            Users[user.Email] = user;
        }
        else
        {
            Users.Add(user.Email, user);
        }
    }
}