using System;

namespace Module34_Multithreading.SupportItems
{
    public class StateWrapper
    {
        public void RunInvestigation(Func<Action<int>> action)
        {
            Console.WriteLine("Start new task.");

            var iterator = 0;
            var func = action.Invoke();
            while (true)
            {
                func(iterator++);
            }
        }
    }
}