using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {

            Qone();
        }
        private static void Qone()
        {
            int result = 0;
            bool flag = true;
            string[] lines = System.IO.File.ReadAllLines(@"../../q1.txt");
            int[] nr = Array.ConvertAll<string, int>(lines, Int32.Parse);
            Dictionary<int, int> freq = new Dictionary<int, int>();
            while (flag)
            {
                foreach (int i in nr)
                {
                    result += i;
                    if (freq.ContainsKey(result))
                    {
                        freq[result]++;
                    }
                    else
                    {
                        freq.Add(result, 1);
                    }
                    if (freq[result] == 2)
                    {
                        flag = false;
                        Console.Write(result);
                        break;
                    }
                }
            }
            Console.Read();
        }
    }
}
