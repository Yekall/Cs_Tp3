using System;
using System.Threading;

namespace TP3
{
    class Program
    {
        private static Mutex mutex = new Mutex();  
        private const int numhits = 1;  
        private static void ThreadProcess()  
        {  
            for (int i = 0; i < numhits; i++)  
            {  
                ex2();  
            }  
        }  
        private static void ex2()  
        {  
            mutex.WaitOne();  
            int num = 10 ;  
            int time  = 10;
            char c  = '_';
            Console.WriteLine(Thread.CurrentThread.Name);
            switch (Thread.CurrentThread.Name)
            
            {
                case ("Thread1"):
                {
                    num = 200;  
                    time = 50;
                    c = '_';
                    break;
                }
                case ("Thread2"):
                {
                    num = 275;  
                    time = 40;
                    c = '*';
                    break;
                }
                case ("Thread3"):
                {
                    num = 450;  
                    time = 20;
                    c = '°';
                    break;
                }
                
            }
            
            do  
            {  
                Thread.Sleep(time);  
                Console.WriteLine(c);  
                num--;  
            } while (num > 0);  
            mutex.ReleaseMutex();   
        }  
        static void Main(string[] args)  
        {  
            for (int i = 0; i < 3; i++)  
            {  
                Thread th = new Thread(ThreadProcess);  
                th.Name = String.Format("Thread{0}", i + 1);  
                th.Start();  
            }  
        }  
    }  
}