using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.BinWork
{
    class BinWorker
    {
        public static bool Reverse(bool bit)
        {
            return bit?false:true;
        }


        public static bool CountMod2(List<bool> bits)
        {
            int result = 0;
            foreach (bool bit in bits)
            {
                int bufBit = bit ? 1 : 0;
                result = (result + bufBit) % 2;
            }

            return result == 1 ? true : false;
        }

        public static int GetFirstTrueIndex(List<bool> bits)
        {
            return bits.IndexOf(true);
        }
        public static List<bool> AddBits(List<bool> bitsA, List<bool> bitsB, int start = 0)
        {
            if (start < 0)
                return bitsA;
            for (int i = start, k = 0; i < bitsA.Count; k++, i++)
            {
                if (k < bitsB.Count)
                    bitsA[i] = AddBit(bitsA[i], bitsB[k]);
                else
                    return bitsA;

            }
            return bitsA;
        }
        public static int CountBits(List<bool> bits)
        {
            int c = 0;
            foreach (var bit in bits)
            {
                if (bit)
                    c++;
            }
            return c;
        }
        public static bool AddBit(bool A, bool B)
        {
            if (A & B)
                return false;
            else
                return A | B;
        }
        public static List<bool> GetDivRemains(List<bool> bitsA, List<bool> bitsB)
        {
            while ((bitsA.Count - GetFirstTrueIndex(bitsA)) >= bitsB.Count & CountBits(bitsA) > 0)
            {
                bitsA = AddBits(bitsA, bitsB, GetFirstTrueIndex(bitsA));
            }
            return bitsA;
        }
        public static List<bool> ConcatBitsToEnd(List<bool> bits, int bitsToAdd ,bool concater = false)
        {
            for(int i = 0; i < bitsToAdd; i++ )
            {
                bits.Add(concater);
            }

            return bits;
        }
        public static List<bool> ConcatBitsToStart(List<bool> bits, int bitsToAdd, bool concater = false)
        {
            List<bool> buf = new List<bool>();
            for (int i = 0; i < bitsToAdd; i++)
            {
                buf.Add(concater);
            }
            buf.AddRange(bits);
            bits = new List<bool>(buf);
            return bits;
        }
        public static List<bool> MoveToLeft(List<bool> bits , int count)
        {
            if(bits.Count > 0)
                for (int i = 0; i < count; i++)
                {
                    bits.Add(bits[0]);
                    bits.RemoveAt(0);
                }
            return bits;
        }
        public static List<bool> MoveToRight(List<bool> bits, int count)
        {
            List<bool> buf = new List<bool>();
            if (bits.Count > 0)
            {
                for (int i = count - 1; i >= count; i--)
                {

                    buf.Add(bits[i]);

                }
                bits.RemoveRange(bits.Count - count , count);
                buf.AddRange(bits);
                bits = buf;
            }
            return bits;
        }
    }
}
