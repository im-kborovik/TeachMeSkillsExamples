using Module30_Async;

var tplLibraryExample = new TplLibraryExample();
tplLibraryExample.SimpleTask();
tplLibraryExample.GenericTask();
tplLibraryExample.ContinuationTask();

var asyncAwaitApproach = new AsyncAwaitApproach();
await asyncAwaitApproach.FirstAsyncMethod();
await asyncAwaitApproach.NotAwaitableTask();
await asyncAwaitApproach.ParallelExecution();

var taskCancellation = new TaskCancellation();
await taskCancellation.RunCancellationExample();