using Module25_LINQ.Common;
using Module25_LINQ.Examples;

var classRunner = new ClassRunner();

classRunner.Run<KindOfLinqQuery>()
           .Use(q => q.PrintEmailsByLinqQuery())
           .Use(q => q.PrintEmailsByExtensionMethods())
           .ReturnToRunner()
           .Run<DataProjection>()
           .Use(q => q.PrintFirstAndLastNames())
           .Use(q => q.FillAddressForUsers())
           .ReturnToRunner()
           .Run<Filtering>()
           .Use(q => q.PrintUsersMoreThenAge(40))
           .ReturnToRunner()
           .Run<Sorting>()
           .Use(q => q.SortUsersByEmailAsc())
           .Use(q => q.SortUsersByEmailDesc())
           .ReturnToRunner()
           .Run<WorkingWithSomeCollections>()
           .Use(q => q.Join())
           .Use(q => q.GroupBy())
           .Use(q => q.Intersect())
           .Use(q => q.Except())
           .Use(q => q.Distinct())
           .ReturnToRunner();