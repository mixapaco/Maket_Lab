using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.CodecsWork
{
     
    class IterativeCodec
    {
        //private bool[,] Matrix;
        private Int32 MaxX = 5;
        private Int32 MaxY = 5;

        public IterativeCodec()
        { 
        }

        public bool[,] CreateMatrix(bool[] bits)
        {
            int x = 0, y = 0;
            bool[,] Matrix = new bool[MaxX + 1, MaxY + 1];

            foreach (bool bit in bits)
            {

                Matrix[x, y] = bit;
                x++;
                if (MaxX <= x)
                {
                    x = 0;
                    y++;
                }

            }

            return Matrix;
        }


        public List<bool> CodeBits(bool[] bits)
        {
            bool[,] matrix = CreateMatrix(bits);

            for (int y = 0; y < MaxY; y++)
            {
                matrix[MaxX, y] = CountMod2(GetRow(matrix, y));

            }
            for (int x = 0; x < MaxX; x++)
            {
                matrix[x, MaxY] = CountMod2(GetColumn(matrix, x));

            }
            matrix[MaxX, MaxY] = CountMod2(GetColumn(matrix, MaxX));

            return CreateArr(matrix);
        }

        public List<bool> CreateArr(bool[,] bits)
        {
            List<bool> buf = new List<bool>();
            for (int y = 0; y < MaxY + 1; y++)
            {
                for (int x = 0; x < MaxX + 1; x++)
                {
                    buf.Add(bits[x, y]);
                }
            }

            return buf;
        }

        public bool[] GetColumn(bool[,] bits, int x)
        {
            bool[] buf = new bool[bits.GetUpperBound(0)];

            for (int y = 0; y < bits.GetUpperBound(0); y++)
            {
                buf[y] = bits[x, y];
            }
            return buf;
        }

        public bool[] GetRow(bool[,] bits, int y)
        {
            bool[] buf = new bool[bits.GetUpperBound(1)];

            for (int x = 0; x < bits.GetUpperBound(1); x++)
            {
                buf[x] = bits[x, y];
            }
            return buf;
        }

        private bool CountMod2(bool[] bits)
        {
            int result = 0;
            foreach (bool bit in bits)
            {
                int bufBit = bit ? 1 : 0;
                result = (result + bufBit) % 2;
            }

            return result == 1 ? true : false;
        }


    }


}
