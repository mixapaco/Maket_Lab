using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.CodecsWork
{
    class LoopCodec
    {
        private List<bool> Polinom;
        private int r;
        private int K;
        private int t;
    
        public LoopCodec(string polinom , int RCount , int kCount , int tCount)
        {
            Polinom = new List<bool>();
            KCount = kCount;
            R = RCount;
            t = tCount;
            foreach (var bit in polinom)
            {
                Polinom.Add(bit == '1' ? true : false);

            }
        }

        public int R { get => r; set => r = value; }
        public int KCount { get => K; set => K = value; }

        public List<bool> CodeBits(List<bool> bits)
        {
            BinWork.BinWorker.ConcatBitsToEnd(bits, r);
            List<bool> Remains = BinWork.BinWorker.GetDivRemains(new List<bool>(bits),Polinom);
            BinWork.BinWorker.AddBits(bits,Remains);
            return bits;
        }
        public List<bool> CodeLineBits(List<bool> bits)
        {
            List<bool> buf = new List<bool>();
            List<bool> res = new List<bool>();

            for (int i = 1, k = 0; k < bits.Count; i++)
            {
                for (; k < i * (K); k++)
                {
                    if (bits.Count == k)
                    {
                        break;
                    }
                    buf.Add(bits[k]);
                }
                if (buf.Count > 0)
                {
                    buf = CodeBits(buf);
                    res.AddRange(buf);
                }
                buf.Clear();
            }

            return res;
        }

        public List<bool> DeCodeLineBits(List<bool> bits)
        {
            List<bool> buf = new List<bool>();
            List<bool> res = new List<bool>();

            for (int i = 1, k = 0; k < bits.Count; i++)
            {
                for (; k < i * (K+R); k++)
                {
                    if (bits.Count == k)
                    {
                        break;
                    }
                    buf.Add(bits[k]);
                }
                if (buf.Count > 0)
                {
                    buf = DeCodeBits(buf);
                    res.AddRange(buf);
                }
                buf.Clear();
            }

            return res;
        }
        public List<bool> DeCodeBits(List<bool> bits)
        {
            bits = FixError(bits);
            bits.RemoveRange(bits.Count - R, R);
            return bits;
        }
        public List<bool> FixError(List<bool> bits)
        {
            List<bool> remain = BinWork.BinWorker.GetDivRemains(new List<bool>(bits), Polinom);
            int RemainsCount2 = BinWork.BinWorker.CountBits(remain);
            if (RemainsCount2 == 0)
                return bits;
            int q = 0;
            List<bool> buf = new List<bool>(bits);
            while (RemainsCount2 > 1)
            {
                BinWork.BinWorker.MoveToLeft(buf, 1);
                remain = BinWork.BinWorker.GetDivRemains(new List<bool>(buf), Polinom);
                RemainsCount2 = BinWork.BinWorker.CountBits(remain);
                q++;
                if (q > buf.Count)
                    return bits;
            }
            BinWork.BinWorker.AddBits(BinWork.BinWorker.MoveToLeft(bits,q) , remain);
            bits = BinWork.BinWorker.MoveToRight(bits, q);
            return bits;
        }
    }
}
