using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    internal class Bank
    {
        public int Money { get; set; }
        public string Name { get; set; }
        public int Percent { get; set; }

        private readonly Thread thread;

        public Bank(int money, string name, int percent)
        {
            ThreadStart threadStart = new ThreadStart(WriteIntoTextFile);
            thread = new Thread(threadStart);

            Money = money;
            Name = name;
            Percent = percent;
        }

        public void SetInfo(int money, string name, int percent)
        {
            Money = money;
            Name = name;
            Percent = percent;

            thread.Start();
        }

        private void WriteIntoTextFile()
        {
            using (StreamWriter writer = new StreamWriter("bank.txt", false, Encoding.UTF8))
            {
                string data = $"Money = {Money}\nName = {Name}\nPercent = {Percent}";
                writer.WriteLine(data);
            }
        }
    }
}
