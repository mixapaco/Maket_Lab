using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.BinWork
{
    class Matrix
    {

        static public List<List<bool>> CreateMatrix(List<bool> bits,int MaxX, int MaxY)
        {

            List<List<bool>> Matrix = new List<List<bool>>() ;

            List<bool> buf = new List<bool>();
            
            for(int y = 0, i = 0; y < MaxY; y++)
            {
                for (int x = 0; x < MaxX; x++)
                {
                    if(bits.Count > i)
                        buf.Add(bits[i++]);
                    else
                        buf.Add(false);
                }
                Matrix.Add(new List<bool>(buf));
                buf.Clear();
            }

            return Matrix;
        }

        static public List<bool> GetRow(List<List<bool>> bits, int y)
        {
            List<bool> buf = bits[y];

            return buf;
        }

        static public List<bool> GetColumn(List<List<bool>> bits, int x)
        {
            List<bool> buf = new List<bool>();

            for (int y = 0; y < bits.Count; y++)
            {
                buf.Add(bits[y][x]);
            }
            return buf;
        }

        static public List<bool> CreateArr(List<List<bool>> bits)
        {
            List<bool> buf = new List<bool>();
            for (int y = 0; y < bits.Count; y++)
            {
                for (int x = 0; x < bits[y].Count; x++)
                {
                    buf.Add(bits[y][x]);
                }
            }

            return buf;
        }

        static public List<List<bool>> RemoveColumn(List<List<bool>> bits, int x)
        {
            
            foreach (var bit in bits)
            {
                bit.RemoveAt(bit.Count-1);
            }
            return bits;
        }

    }
}
