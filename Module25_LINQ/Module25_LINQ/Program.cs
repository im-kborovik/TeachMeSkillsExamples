﻿using Module25_LINQ.Common;
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
           .Use(q => q.Union())
           .ReturnToRunner()
           .Run<AggregateFunctions>()
           .Use(q => q.Aggregate())
           .Use(q => q.MaxMinAvgSum())
           .Use(q => q.Count())
           .ReturnToRunner()
           .Run<TakePartOfCollection>()
           .Use(q => q.SkipTake())
           .Use(q => q.SkipTakeWhile())
           .ReturnToRunner()
           .Run<ElementContaining>()
           .Use(q => q.Any())
           .Use(q => q.All())
           .Use(q => q.Contains())
           .Use(q => q.FirstAndSingle())
           .ReturnToRunner()
           .Run<LazyLoading>()
           .Use(q => q.Example());