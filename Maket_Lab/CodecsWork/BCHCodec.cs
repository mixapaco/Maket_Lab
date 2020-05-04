using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.CodecsWork
{
    class BCHCodec
    {

        private int tmin;
        private int m;

        public int Tmin { get => tmin; set => tmin = value; }
        public int M { get => m; set => m = value; }

        public BCHCodec( int m,int tmin)
        {
            Tmin = tmin;
            M = m;
        }

        public List<bool> CreatePolinom() 
        {
            List<bool> bitsA = new List<bool>() { false, true, false, false, true, true };
            List<bool> bitsB = new List<bool>() { false, true, true, true, true, true };
            List<bool> bitsC = new List<bool>() { false, false, false, false, false, false, false, false, false, true, true, true };
            List<bool> bits1 = new List<bool>() { true ,true};
            bitsA = BinWork.BinWorker.MultBits(bitsA, bitsB);
            bitsC = BinWork.BinWorker.MultBits(bitsC, bitsA);
            bitsC = BinWork.BinWorker.MultBits(bitsC, bits1);

            bitsC.RemoveRange(0,BinWork.BinWorker.GetFirstTrueIndex(bitsC));
            return bitsC;
        }


    }
}
