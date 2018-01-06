using System;
using System.Threading;

namespace MultiThreadDEMO
{
    class MultiThreadTest
    {
        public static void CallToChildThread()
        {
            Console.WriteLine("Child thread starts");
            //int sleepDuration = 5000;
            //Console.WriteLine("Child thread will be pasued for {0} seconds", sleepDuration/1000);
            //manage the thread
            //Thread.Sleep(sleepDuration);
            try
            {
                for (int counter = 1; counter <= 10; counter++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Paused for 0.5sec > " + counter);
                }
                Console.WriteLine("Child thread finishes");
            } catch(Exception)
            {
                Console.WriteLine("Child thread raises exception and exits");
            } finally
            {
                Console.WriteLine("Child thread exits abruptly");
            }
        }

        public static void MultiThreadMain()
        {
            //create a thread
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("Main creating the Child thread");
            Thread childThread = new Thread(childref);
            //start the thread
            childThread.Start();
            //buffer time (0.05sec) to recover the execution time of other commands in the thread
            Thread.Sleep(2050);
            Console.WriteLine("Main destroying the Child thread");
            //destroy the thread
            childThread.Abort();
        }
    }
}
