using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.CodecsWork // невідомо як але воно паше краще не рухай, якщо не знаєш що робиш.
{
    class ViterbiCodec
    {
       
        private static List<bool>[] ViterbiCoef =
            {
            new List<bool>() {  false,   false   },
            new List<bool>() {  true,    true    },
            new List<bool>() {  true,   false    },
            new List<bool>() {  false,    true   },
            new List<bool>() {  true,    true    },
            new List<bool>() {  false,   false   },
            new List<bool>() {  false,    true   },
            new List<bool>() {  true,   false    },
            };
        private static List<List<List<bool>>> Ways;
        private static List<bool>[] GetViterbiCoef()
        { 
            return ViterbiCoef;
        }
        public static List<bool> DecodeBits(List<bool> bits)
        {
            int[] weight = {0,0,0,0};
            ViterbiCoef =  GetViterbiCoef();
            Ways = new List<List<List<bool>>>();

            int step = 1;
            if(bits.Count >= 2)
            for (int i = 0; i < bits.Count; i+=2)
            {
                    List<bool> buf = new List<bool>
                    {
                        bits[i],
                        bits[i + 1]
                    };
                    CalculateWeight(ref weight, buf, step);
                if(step <= 2)
                {
                    step *= 2;
                }
            }
            
            bits = TraceBack(Ways , weight);
            
            return bits;
        }

        private static bool DecodeWay(List<bool> way , ref int index)
        {
            int buf = 0;
            bool val = false;
            if(index == 0)
            {
                if (way[0] && way[1])
                {
                    buf = 2;
                    val = false;
                    
                }
                if (!way[0] && !way[1])
                {
                    buf = 0;
                    val = false;
                }
            }
            if (index == 1)
            {
                if (way[0] && way[1])
                {
                    buf = 0;
                    val = true;
                }
                if (!way[0] && !way[1])
                {
                    buf = 2;
                    val = true;
                }
            }
            if (index == 2)
            {
                if (way[0] && !way[1])
                {
                    val = false;
                    buf = 1;
                }
                if (!way[0] && way[1])
                {
                    buf = 3;
                    val = false;
                }
            }
            if (index == 3)
            {
                if (!way[0] && way[1])
                {
                    buf = 1;
                    val = true;
                }
                if (way[0] && !way[1])
                {
                    buf = 3;
                    val = true;
                }
            }
            index = buf;
            return val;
        }
        private static List<bool> TraceBack(List<List<List<bool>>> ways , int[] weights)
        {
            int min = Array.IndexOf(weights, weights.Min()); ;
            List<bool> BufBits = new List<bool>();
            List<bool> bits = new List<bool>();
            for (int i = ways.Count - 1; i >= 0; i--)
            {
                var buf = ways[i][min];
                BufBits.AddRange(ways[i][min]);
                bits.Add(DecodeWay(ways[i][min],ref min));
                
            }

            return bits;
        }

        public static List<bool> DecodeLineBits(List<bool> bits)
        {
            return DecodeBits(bits);

            //return bits;
        }

        private static List<bool> CalculateWeight(ref int[] weight , List<bool> bits , int step = 4 )
        {
            int[] EveryWeight = { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < EveryWeight.Length && i < step*2; i++)
            {
                EveryWeight[i] += BinWork.BinWorker.CountBits(BinWork.BinWorker.AddBits(new List<bool>(ViterbiCoef[i]), bits));
            }

            weight = SetWeight(EveryWeight,weight , step);
            
            return null;
        }
        private static int[] SetWeight(int[] Eweight, int[] weight , int step)//погано написаний код переписати нормально колись ( ніколи^) )
        {
            List<List<bool>> BufWays = new List<List<bool>>();
            int[] buf = { 0, 0, 0, 0 };
            if (step == 1)
            {
                BufWays.Add(new List<bool>() { false, false });
                BufWays.Add(new List<bool>() { true, true });
                BufWays.Add(new List<bool>() { true, false });
                BufWays.Add(new List<bool>() { false, true });
                Ways.Add(BufWays);
                buf[1] = Eweight[1];
                buf[0] = Eweight[0];
                weight = buf;
                return weight;
            }
            if (step == 2)
            {
                BufWays.Add(new List<bool>() { false, false });
                BufWays.Add(new List<bool>() { true, true });
                BufWays.Add(new List<bool>() { true, false });
                BufWays.Add(new List<bool>() { false, true });
                Ways.Add(BufWays);
                buf[0] += Eweight[0] + weight[0];
                buf[1] = Eweight[1] + weight[0];
                buf[2] = Eweight[2] + weight[1];
                buf[3] = Eweight[3] + weight[1];
                weight = buf;
                return weight;
            }
            
            List<bool> BufWay = new List<bool>();
            buf[0] += CompareWeight(Eweight, weight, 0, ref BufWay);
            BufWays.Add(new List<bool>(BufWay));
            buf[1] += CompareWeight(Eweight, weight, 1, ref BufWay);
            BufWays.Add(new List<bool>(BufWay));
            buf[2] += CompareWeight(Eweight, weight, 2, ref BufWay);
            BufWays.Add(new List<bool>(BufWay));
            buf[3] += CompareWeight(Eweight, weight, 3, ref BufWay);
            BufWays.Add(new List<bool>(BufWay));
            Ways.Add(BufWays);
            weight = buf;
            return weight;
        }
        private static int CompareWeight(int[] Eweight , int[] weight , int index , ref List<bool> way)
        {
            int Comp1index = 0;
            int Comp2index = 0;
            int windex1 = 0;
            int windex2 = 0;

            if (index == 0)
            {
                Comp1index = 0;
                Comp2index = 4;
                windex1 = 0;
                windex2 = 2;
              
            }
            if (index == 1)
            {
                Comp1index = 1;
                Comp2index = 5;
                windex1 = 0;
                windex2 = 2;

            }
            if (index == 2)
            {
                Comp1index = 2;
                Comp2index = 6;
                windex1 = 1;
                windex2 = 3;

            }
            if (index == 3)
            {
                Comp1index = 3;
                Comp2index = 7;
                windex1 = 1;
                windex2 = 3;

            }
            if (Eweight[Comp1index] + weight[windex1] >= Eweight[Comp2index] + weight[windex2])
            {
                
                way = ViterbiCoef[Comp2index];
                return weight[windex2] + Eweight[Comp2index];
            }
            else
            {
                way = ViterbiCoef[Comp1index];
                return weight[windex1] + Eweight[Comp1index];
            }

        }
        private static int CompareInt(int a , int b) 
        {
            return (a > b) ? a : b;
        }
    }
}
