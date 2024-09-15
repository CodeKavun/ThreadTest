using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            ParameterizedThreadStart threadCallback = new ParameterizedThreadStart(IterateThrouhElements);
            Thread collectionThread = new Thread(threadCallback);

            collectionThread.Start(new int[] { 3, 12, 56, 222, 333, 666, 777, 12321 });

            Console.ReadKey();

            // 2
            Bank bank = new Bank(1500, "DIMON", 70);
            bank.SetInfo(1300, "DIMON", 70);
        }

        static void IterateThrouhElements(object collection)
        {
            int[] objects = (int[])collection;
            foreach (object obj in objects) Console.WriteLine(obj.ToString());
        }
    }
}
