using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module34_Multithreading
{
    public class ThreadBasic
    {
        public void SimpleThreadExample()
        {
            var thread1 = new Thread(Print);
            thread1.Start();
            var thread2 = new Thread(() => Console.WriteLine("Here is lambda approach"));
            thread2.Start();

            Console.WriteLine("Here is main thread finished");
            
            Thread.Sleep(5000);
        }

        public void ParameterizedThreads()
        {
            var thread = new Thread(MethodWithParameter);
            thread.Start(nameof(ParameterizedThreads));
        }

        public void ThreadProblems()
        {
            var state = new State();

            for (var i = 0; i < 20; i++)
            {
                Task.Run(() => new StateWrapper().RunInvestigation(state));
            }
            
            Thread.Sleep(5000);
        }

        private void Print()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Hey! Here is method approach of threading 2 seconds soon");
        }

        private void MethodWithParameter(object obj)
        {
            if (obj is string str)
            {
                Console.WriteLine($"Here is string with value: {str}");
            }
        }

        private class StateWrapper
        {
            public void RunInvestigation(State state)
            {
                Console.WriteLine("Start new task.");

                var iterator = 0;
                while (true)
                {
                    state.ChangeState(iterator++);
                }
            }
        }

        private class State
        {
            private int _state;

            public void ChangeState(int iteration)
            {
                if (_state == 0)
                {
                    _state++;
                    if (_state != 1)
                    {
                        Console.WriteLine($"Thread competition is appeared on {iteration} iteration");
                        throw new Exception("Thread competition is finished");
                    }
                }

                _state = 0;
            }
        }
    }
}