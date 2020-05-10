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
        private int n;
        private int r;
        private int k;
        private int dmin;
        public int Tmin { get => tmin; set => tmin = value; }
        public int M { get => m; set => m = value; }

        public BCHCodec( int m,int tmin)
        {
            Tmin = tmin;
            dmin = Tmin * 2 + 1;
            M = m;
            n = (int)Math.Pow(2, M) - 1;
            r = (int)Math.Log(N + 1 ,2.0) * Tmin;
            k = N - R;

        }

        public int K { get => k; }
        public int R { get => r; }

        public int N { get => n;}
        public int Dmin { get => dmin;  }

        public List<bool> CreatePolinom() 
        {

            List<List<bool>> polyList = getMultyPolynoms();
            
            if(polyList.Count == 1)
            {
                polyList[0].RemoveRange(0, BinWork.BinWorker.GetFirstTrueIndex(polyList[0]));
                return polyList[0];
            }

            List<bool> res = BinWork.BinWorker.MultBits(polyList[0],polyList[1]);
            for (int i = 2; i < polyList.Count; i++)
            {
                res = BinWork.BinWorker.MultBits(polyList[i], res);

            }

            res.RemoveRange(0,BinWork.BinWorker.GetFirstTrueIndex(res));
            return res;
        }
        public List<List<bool>> getMultyPolynoms()//поки що захардкоджено зроби автоматичне вичеслення НСК 
        {
            
            List<List<bool>>[] Poly = new List<List<bool>>[8];
            Poly[2] = new List<List<bool>>() { new List<bool>() { true, true, true } };
            Poly[3] = new List<List<bool>>() { new List<bool>() { false, false, true, false, true, true }, null , new List<bool>() { false, false, true, true, false, true } };
            Poly[4] = new List<List<bool>>() { new List<bool>() { false, true, false, false, true, true }, new List<bool>() { false, true, true, true, true, true }, new List<bool>() { false, false, false, true, true, true }, null , null , null , new List<bool>() { false, true, true, false, false, true } };
            Poly[5] = new List<List<bool>>() { new List<bool>() { true, false, false, true, false, true }, new List<bool>() { true, true, true, true, false, true }, new List<bool>() { true, true, false, true, true, true }, null, new List<bool>() { true, false, true, true, true, true }, null, new List<bool>() { true, true, true, false, true, true } };
            Poly[6] = new List<List<bool>>() {  new List<bool>() { false, false, true, false, false, false, false, true, true }, 
                                                new List<bool>() { false, false, true, false, true, true, true, true, true }, 
                                                new List<bool>() { false, false, true, true, false, false, true, true, true },
                                                new List<bool>() { false, false, true, false, false, true, false, false, true},
                                                new List<bool>() { false, false, false, false, false, true, true, false, true},
                                                new List<bool>() { false, false, true, true, false, true, true, false, true},
                                                new List<bool>() { false, false, true, false, true, true, false, true, true },
                                                null,
                                                null,
                                                new List<bool>() { false, false, true, true, true, false, true, false, true },
                                                new List<bool>() { false, false, false, false, false, false, true, true, true },
                                            };

            Poly[7] = new List<List<bool>>() {  new List<bool>() { false, true, false, false, false, true, false, false, true },
                                                new List<bool>() { false, true, false, false, false, true, true, true, true },
                                                new List<bool>() { false, false, true, false, true, true, true, false, true },
                                                new List<bool>() { false, true, true, true, true, false, true, true, true},                                                
                                                new List<bool>() { false, true, false, true, true, true, true, true, true},
                                                new List<bool>() { false, true, true, false, true, false, true, false, true },
                                                new List<bool>() { false, true, false, false, false, false, false, true, true},
                                                null,
                                                new List<bool>() { false, true, true, true, false, true, true, true, true },
                                                new List<bool>() { false, true, true, false, false, true, false, true, true },
                                                new List<bool>() { false, true, true, true, false, false, true, false, true },
                                             };
            List<List<bool>> res = new List<List<bool>>();
            for (int i = 0; i < Tmin && i < Poly[m].Count(); i++)
            {
                if(Poly[m][i] != null)
                {
                    res.Add( Poly[m][i]);
                }
            }



            return res;
        }


    }
}
