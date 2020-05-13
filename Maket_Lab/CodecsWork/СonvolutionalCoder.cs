using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.CodecsWork
{
    class СonvolutionalCoder
    {

        public static List<bool> CodeBits(List<bool> bits)
        {
            return CodeSystem(bits);

            //return bits;
        }

        public static List<bool> CodeLineBits(List<bool> bits)
        {
            return CodeBits(bits);

            //return bits;
        }

        public static List<bool> CodeSystem(List<bool> bits)
        {
            List<bool> register = new List<bool>() { false ,false ,false};
            List<bool> res = new List<bool>();
            foreach (var bit in bits)
            {
                register = BinWork.BinWorker.MoveToRight(register, 1);
                register[0] = bit;
                bool r = BinWork.BinWorker.AddBit(register[0],register[2]);
                res.Add(register[0]);
                res.Add(r);
            }

            return res;
        }


    }
}
