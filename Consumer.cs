using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    public class Consumer
    {
        public void ConsumeArray(object callback)
        {
            //Stack
            while (true)
            {

                try
                {
                    if (Monitor.TryEnter(Program.cookieArray))
                    {
                        // Waits for cookies if the Index of array
                        if (Program.Index == 0)
                        {
                            Monitor.Wait(Program.cookieArray);
                        }
                        else
                        {


                            Program.consumedArrayCookies.Add(Program.cookieArray[Program.Index]);
                            Program.cookieArray[Program.Index] = null;
                            Program.Index--;

                        }

                    }

                }
                finally
                {
                    if (Monitor.IsEntered(Program.cookieArray))
                        Monitor.Exit(Program.cookieArray);
                    Thread.Sleep(200);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        public void ConsumeQueue(object callback)
        {
            while (true)
            {
                try
                {
                    if (Monitor.TryEnter(Program.cookieQ))
                    {
                        if (Program.cookieQ.Count == 0)
                        {
                            Monitor.Wait(Program.cookieQ);
                        }
                        else
                        {
                            Program.consumedQueueCookies.Add(Program.cookieQ.Dequeue());
                        }
                    }

                }
                finally
                {
                    if (Monitor.IsEntered(Program.cookieQ))
                        Monitor.Exit(Program.cookieQ);

                    Thread.Sleep(200);
                }
            }
        }
    }
}
