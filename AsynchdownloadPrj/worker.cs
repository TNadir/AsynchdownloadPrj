using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchdownloadPrj
{
    public class worker
    {
        public bool IsComplete { get; private set; }
        public int Value { get; private set; }

        public async void DoWork()
        {
            this.IsComplete = false;
          //  Console.WriteLine("Doing work");
            await Task.Run(() =>
            {
                // Console.WriteLine("Working start");
                //Thread.Sleep(6000);
                for (int i = 0; i < 100; i++)
                {
                    //Console.WriteLine(i);
                    // this.Value = i;
                    this.Value = i;
                    // Thread.Sleep(60);
                }
                //  Console.WriteLine("Working end");
            });
            // Console.WriteLine("Work completed");
            this.IsComplete = true;
        }

        private  Task LongOperation()
        {
           return Task.Run(() =>
            {
                // Console.WriteLine("Working start");
                //Thread.Sleep(6000);
                for (int i = 0; i < 100; i++)
                {
                    //Console.WriteLine(i);
                    // this.Value = i;
                    this.Value = i;
                    // Thread.Sleep(60);
                }
                //  Console.WriteLine("Working end");
            });

        }
    }
}
