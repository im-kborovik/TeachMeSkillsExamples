using Module25_LINQ.Data.Entities;

namespace Module25_LINQ.Data;

public interface IDataStorage
{
    IReadOnlyCollection<User> GetUsers();

    IReadOnlyCollection<Product> GetProducts();

    string AddRandomUser();
}