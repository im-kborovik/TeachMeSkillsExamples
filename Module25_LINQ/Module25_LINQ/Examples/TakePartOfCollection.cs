using Module25_LINQ.Common;
using Module25_LINQ.Data;
using Module25_LINQ.Helpers;

namespace Module25_LINQ.Examples;
/// <summary>
/// Этот пример показывает как можно получать определённые части коллекции
/// </summary>
public class TakePartOfCollection : DataService
{
    public TakePartOfCollection(DataStorage storage) : base(storage)
    {
    }

    public void SkipTake()
    {
        Users.PrintItems();
        var secondUser = Users.Skip(1)
                              .Take(1);
        secondUser.PrintItems();
    }

    public void SkipTakeWhile()
    {
        Users.PrintItems();
        var min = Users.Min(q => q.Age);
        var firstUserAfterMin = Users.SkipWhile(q => q.Age != min)
                                     .Take(1);
        
        firstUserAfterMin.PrintItems(nameof(firstUserAfterMin));
        
        var takeUsersBeforeMin = Users.TakeWhile(q => q.Age != min);
        
        takeUsersBeforeMin.PrintItems(nameof(takeUsersBeforeMin));
    }
}