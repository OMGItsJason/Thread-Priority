using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace Thread_Priority
{
    public partial class FrmTrackThread : Window
    {
        
        public FrmTrackThread()
        {
            InitializeComponent();
        }

        private void BtnRun_OnClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("-Thread Start-");
            ThreadPriority[] priorities = {
                ThreadPriority.Highest,
                ThreadPriority.Normal,
                ThreadPriority.AboveNormal,
                ThreadPriority.BelowNormal
            };

            List<Thread> threads = new List<Thread>();

            for (int t = 0; t < priorities.Length; t++)
            {
                string threadName = "Thread " + (char)('A' + t);
                Thread thread1 = new Thread(() => MyThreadClass.Thread1(threadName));
                thread1.Priority = priorities[t];
                thread1.Start();
                threads.Add(thread1);

                Thread thread2 = new Thread(() => MyThreadClass.Thread2(threadName));
                thread2.Priority = priorities[t];
                thread2.Start();
                threads.Add(thread2);
            }
            
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("-End Of Thread-");
            ThreadStartEnd.Text = "-End Of Thread-";
        }
        
    }

    class MyThreadClass
    {
        public static string Thread1(string thread)
        {
            Thread thread1 = Thread.CurrentThread;
            for (int LoopCount = 0; LoopCount < 2; LoopCount++)
            {
                Console.WriteLine("Name of Thread: " + thread + " = " + LoopCount);
                Thread.Sleep(500);
            }
            return thread;
        }

        public static string Thread2(string _thread)
        {
            Thread thread2 = Thread.CurrentThread;
            for (int LoopCount = 0; LoopCount <= 6; LoopCount++)
            {
                Console.WriteLine("Name of Thread: " + _thread + " = " + LoopCount);
                Thread.Sleep(1500);
            }
            return _thread;
        }
    }
}