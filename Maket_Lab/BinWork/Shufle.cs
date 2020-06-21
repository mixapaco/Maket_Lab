using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.BinWork
{
    class Shufle
    {
        private int X;
        private int Y;
        public Shufle(int x , int y)
        {
            X = x;
            Y = y;
        }
        public static List<bool> ShufleBits(List<bool> bits , int x , int y)
        {
            List<bool> buf = new List<bool>();
            int offset = 0;
            for (int i = 1; offset < bits.Count; i++)
            {
                buf.AddRange(Transpose(bits , x , y ,offset));
                offset = x * y * i;
            }
            return buf;
        }
        private static List<bool> Transpose(List<bool> bits, int x, int y, int offset)
        {
            List<bool> buf = new List<bool>();
            for (int j = 0; j < x; j++)
            {
                for (int i = 0; i < y; i++)
                {
                    buf.Add(bits.ElementAtOrDefault(i * x + j + offset));
                }
            }
            return buf;
        }
    }
}
