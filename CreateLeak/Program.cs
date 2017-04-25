using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreateLeak
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var list = new List<byte[]>();
            while (true)
            {
                byte[] b = new byte[1024];
                b[rnd.Next(0, b.Length)] = byte.MaxValue;
                list.Add(b);

                Thread.Sleep(10);
            }
        }
    }
}
