using System;
using System.Threading;

namespace Module34_Multithreading.SupportItems
{
    public class State
    {
        private static readonly object Locker = new object();

        private int _state;

        public void ChangeStateWithoutLocking(int iteration)
        {
            ChangeState(iteration);
        }

        public void ChangeStateSyncByLock(int iteration)
        {
            lock (Locker)
            {
                ChangeState(iteration);
            }
        }

        public void ChangeStateSyncByMonitor(int iteration)
        {
            var obj = new object();
            Monitor.Enter(obj);

            ChangeState(iteration);

            Monitor.Exit(obj);
        }

        public void ChangeStateSyncByMutex(int iteration)
        {
            var mutex = new Mutex();
            mutex.WaitOne();

            ChangeState(iteration);

            mutex.ReleaseMutex();
        }

        public void ChangeStateSyncBySemaphore(int iteration)
        {
            var semaphore = new Semaphore(1, 1);

            semaphore.WaitOne();
            
            ChangeState(iteration);

            semaphore.Release();
        }

        public void ChangeStateSyncByAutoResetEvent(int iteration)
        {
            var autoResetEvent = new AutoResetEvent(true);

            autoResetEvent.WaitOne();
            
            ChangeState(iteration);

            autoResetEvent.Set();
        }

        private void ChangeState(int iteration)
        {
            if (_state == 0)
            {
                _state++;
                if (_state != 1)
                {
                    Console.WriteLine($"Thread competition is appeared on {iteration} iteration");
                    throw new Exception("Thread competition is finished");
                }
                else
                {
                    Console.WriteLine($"State is {_state}");
                }
            }

            _state = 0;
        }
    }
}