using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.BinWork
{
    class BinWorker
    {
        static public bool Reverse(bool bit)
        {
            return bit?false:true;
        }


        static public bool CountMod2(List<bool> bits)
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
