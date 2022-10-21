using System;

namespace Module34_Multithreading
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var threadBasic = new ThreadBasic();
            // threadBasic.SimpleThreadExample();
            // threadBasic.ParameterizedThreads();
            
            // threadBasic.ThreadProblems((stateWrapper, state) => stateWrapper.RunInvestigation(() => state.ChangeStateWithoutLocking));
            // threadBasic.ThreadProblems((q, w) => q.RunInvestigation(() => w.ChangeStateSyncByLock));
            // threadBasic.ThreadProblems((q, w) => q.RunInvestigation(() => w.ChangeStateSyncByMonitor));
            // threadBasic.ThreadProblems((q, w) => q.RunInvestigation(() => w.ChangeStateSyncByMutex));
            // threadBasic.ThreadProblems((q, w) => q.RunInvestigation(() => w.ChangeStateSyncBySemaphore));
            threadBasic.ThreadProblems((q, w) => q.RunInvestigation(() => w.ChangeStateSyncByAutoResetEvent));
        }
    }
}