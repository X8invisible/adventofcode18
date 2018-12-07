using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answers
{
    class Program
    {
        static void Main(string[] args)
        {

            // Qone();
            //Qthree();
            Qfour();
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

        private static void Qthree()
        {
            int counter = 0;
            string[] lines = System.IO.File.ReadAllLines(@"../../q3.txt");
            List<int> theOne = new List<int>();
            int[,] fabric = new int[1000,1000];
            foreach(string s in lines)
            {
                string[] elements = s.Split(new Char[] { ' ', '@', '#', ',', ':', 'x' }, StringSplitOptions.RemoveEmptyEntries);
                int id = Int32.Parse(elements[0]);
                int i = Int32.Parse(elements[1]);
                int j = Int32.Parse(elements[2]);
                int w = Int32.Parse(elements[3]);
                int h = Int32.Parse(elements[4]);
                bool intact = true;
                for(int a = i; a< i+w; a++)
                {
                    for (int b = j; b < j + h; b++)
                    {
                        if(fabric[a,b] == 0)
                        {
                            fabric[a, b] = id;
                        }
                        else
                        {
                            if(fabric[a,b]!= -1)
                            {
                                theOne.Remove(fabric[a, b]);
                            }
                            intact = false;
                            fabric[a, b] = -1;
                        }
                    }
                }
                if (intact)
                    theOne.Add(id);
            }
            for(int c= 0; c < 1000; c++)
            {
                for(int d =0;d< 1000; d++)
                {
                   // Console.Write(fabric[c, d]+"   ");
                    if (fabric[c, d] == -1)
                        counter++;
                }
                //Console.WriteLine("");
            }
            Console.WriteLine(counter);
            Console.WriteLine(theOne[0]+" "+theOne.Count);
            Console.Read();
        }
        private static void Qfour()
        {
            string[] lines = System.IO.File.ReadAllLines(@"../../q4.txt");
            for(int i = 0; i < lines.Length; i++)
            {
                for (int j = i; j < lines.Length; j++)
                {
                    string[] e = lines[i].Split(new Char[] { ' ', ']', '[', '-', ':'}, StringSplitOptions.RemoveEmptyEntries);
                    string[] el = lines[j].Split(new Char[] { ' ' , ']', '[', '-', ':'}, StringSplitOptions.RemoveEmptyEntries);
                    DateTime d1 = new DateTime(Int32.Parse(e[0]), Int32.Parse(e[1]), Int32.Parse(e[2]), Int32.Parse(e[3]), Int32.Parse(e[4]),0);
                    DateTime d2 = new DateTime(Int32.Parse(el[0]), Int32.Parse(el[1]), Int32.Parse(el[2]), Int32.Parse(el[3]), Int32.Parse(el[4]), 0);
                    if(d1.CompareTo(d2) > 0)
                    {
                        string temp = lines[i];
                        lines[i] = lines[j];
                        lines[j] = temp;
                    }
                }
            }
            int id = 0;
            int start = -1;
            int stop = -1;
            Dictionary<int, int> laziest = new Dictionary<int, int>();
            foreach(string s in lines)
            {
                string[] e = s.Split(new Char[] { ' ', ']', '[', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (e[5] == "Guard")
                {
                    id = Int32.Parse(e[6].Trim(new Char[] { '#' }));
                }
                else if(e[5] == "falls")
                {
                    start = Int32.Parse(e[4]);
                }else if(e[5] == "wakes")
                {
                    stop = Int32.Parse(e[4]);
                    int mins = stop - start;
                    if (laziest.ContainsKey(id))
                    {
                        laziest[id] += mins;
                    }
                    else
                    {
                        laziest.Add(id, mins);
                    }
                }

            }
            int biggest = 0;
            foreach(int key in laziest.Keys)
            {
                //Console.WriteLine(key+" "+laziest[key]);
                if(laziest[key]>biggest)
                {
                    biggest = laziest[key];
                    id = key;
                }
               
            }
            start = -1;
            stop = -1;
            int cid = 0;
            int[] lazyMins = new int[60];
            foreach (string s in lines)
            {
                string[] e = s.Split(new Char[] { ' ', ']', '[', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (e[5] == "Guard")
                {
                    cid = Int32.Parse(e[6].Trim(new Char[] { '#' }));
                }
                else if (e[5] == "falls" && cid == id)
                {
                    start = Int32.Parse(e[4]);
                }
                else if (e[5] == "wakes" && cid == id)
                {
                    stop = Int32.Parse(e[4]);
                    for (int m = start;m < stop; m++)
                    {
                        lazyMins[m]++;
                    }
                }
            }
            biggest = 0;
            for(int m = 0;m<60;m++)
            {
                if (lazyMins[m] > lazyMins[biggest])
                    biggest = m;
                //Console.WriteLine(m);
            }
            Console.WriteLine(id*biggest);

            Dictionary<int, int[]> lazyCon = new Dictionary<int, int[]>();
            int[] mi;
            foreach (string s in lines)
            {
                string[] e = s.Split(new Char[] { ' ', ']', '[', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (e[5] == "Guard")
                {
                    id = Int32.Parse(e[6].Trim(new Char[] { '#' }));
                    if (lazyCon.ContainsKey(id))
                    {
                        mi = lazyCon[id];
                    }
                    else
                    {
                        lazyCon.Add(id, new int[60]);
                        mi = lazyCon[id];
                    }
                }
                else if (e[5] == "falls")
                {
                    start = Int32.Parse(e[4]);
                }
                else if (e[5] == "wakes")
                {
                    stop = Int32.Parse(e[4]);
                    for (int m = start; m < stop; m++)
                    {
                        lazyCon[id][m]++;
                    }
                }

            }
            int gid = 0;
            int theOne = 0;
            bool started = false;
            foreach(int key in lazyCon.Keys)
            {
                biggest = 0;
                for (int m = 0; m < 60; m++)
                {
                    if (lazyCon[key][m] > lazyCon[key][biggest])
                        biggest = m;
                }
                
                if (started)
                {
                    if (lazyCon[key][biggest] > lazyCon[key][theOne])
                    {
                        gid = key;
                        theOne = biggest;
                    }
                }
                else
                {
                    started = true;
                    gid = key;
                    theOne = biggest;
                }
                Console.WriteLine(theOne + " " + gid);
            }
            Console.WriteLine(gid * theOne);
            Console.Read();
        }
    }
}
