using Module25_LINQ.Data;
using Module25_LINQ.Data.Entities;

namespace Module25_LINQ.Common;

public abstract class DataService
{
    protected readonly DataStorage Storage;

    public DataService(DataStorage storage)
    {
        Storage = storage;
    }

    protected IReadOnlyCollection<User> Users => Storage.GetUsers();

    protected IReadOnlyCollection<Product> Products => Storage.GetProducts();
}