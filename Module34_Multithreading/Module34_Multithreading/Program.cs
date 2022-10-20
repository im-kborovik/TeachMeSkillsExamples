using System;

namespace Module34_Multithreading
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var threadBasic = new ThreadBasic();
            threadBasic.SimpleThreadExample();
            threadBasic.ParameterizedThreads();
            threadBasic.ThreadProblems();
        }
    }
}