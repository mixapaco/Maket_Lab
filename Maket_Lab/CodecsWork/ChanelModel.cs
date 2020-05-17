using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.CodecsWork
{
    class ChanelModel
    {

        private int TypeSymetry;
        public ChanelModel(int typeSymetry = 1)
        {

            TypeSymetry = typeSymetry;

        }

        private double CalcError(double ErrorPar , bool typeError)
        {
            double ErrorPercent;
            if (typeError)
                ErrorPercent = ErrorPar;
            else
            {
                ErrorPercent = CrampFunc(0.5, ErrorPar);
            }
            return ErrorPercent;
        }
        public List<bool> SingleError(List<bool> bits , double err, bool type)
        {
            Random random = new Random();
            double ErrorPercent = CalcError(err, type);
            for (int i = 0; i < bits.Count; i++)
            {
                if (ErrorPercent >= CodecsWork.RandomErrorGenerator.GenerateErrorPercent(random))
                {
                    bits[i] = ChangeBit(bits[i]);
                }

            }
            return bits;
        }

        public List<bool> PacketError(List<bool> bits , Dictionary<string, double> par)
        {
            Random random = new Random();
            double R1; //випадкове значення 
            int L1 = 0;// довжина послідовності
            for (int i = 0; i < bits.Count; i++)
            {
                R1 = CodecsWork.RandomErrorGenerator.GenerateErrorPercent(random);
                
                if (R1 <= par["h1"])
                {
                    L1 = CountPacketLenght(random , par["r1"]);
                }
                else
                {
                    L1 = CountPacketLenght(random, par["r2"]);
                }

                BetweenPacketsError(random , bits ,ref i , L1 , par["ErrorLambda"]);//створення одиночної помилки між пакетами 
                
                R1 = CodecsWork.RandomErrorGenerator.GenerateErrorPercent(random);

                if (R1 <= par["p1"])
                {
                    L1 = CountPacketLenght(random, par["q1"]);
                }
                else if((R1>par["q1"])&&(R1 <= (par["p1"] + par["p2"])))
                {
                    L1 = CountPacketLenght(random, par["q2"]);
                }
                else if (R1 > (par["p1"] + par["p2"]))
                {
                    L1 = CountPacketLenght(random, par["q3"]);
                }

                InPacketsError(random, bits, ref i, L1, par["PacketError"]);// створення пакетної помилки.

            }

            return bits;
        }

        private void InPacketsError(Random random, List<bool> bits, ref int i, int L1, double err)
        {
            for (int j = i; j < bits.Count && j < i+L1; j++)
            {
                if (CodecsWork.RandomErrorGenerator.GenerateErrorPercent(random) <= err)
                    bits[j] = ChangeBit(bits[j]);
            }
            i += L1;

        }

        private void BetweenPacketsError(Random random, List<bool> bits ,ref int i , int L1 , double errLambda)
        {
            for (int j = i; j < bits.Count && j < i + L1; j++)
            {
                if (CodecsWork.RandomErrorGenerator.GenerateErrorPercent(random) <= errLambda)
                    bits[j] = ChangeBit(bits[j]);
            }
            i += L1;
        }
        private int CountPacketLenght(Random random , double errLambda )
        {
            double temp = Math.Log(1 - CodecsWork.RandomErrorGenerator.GenerateErrorPercent(random)) / Math.Log(errLambda);
            int lambda = (int)Math.Truncate(temp);
            return lambda + 1;
        }
        public bool ChangeBit(bool bit)
        {
            if (TypeSymetry == 1)
                return bit ? false : true;
            if (TypeSymetry == 2)
                return true;
            if (TypeSymetry == 3)
                return false;
            return bit;
        }


        double CrampFunc(double gamma, double sn)
        {
            int i;
            double h, x, s, x2;
            double p0;
            h = Math.Sqrt(sn);
            x = gamma * h / Math.Sqrt(2.0);
            x2 = x * x;
            // асимптотична формула
            if (gamma * h > 6.0)
            {
                p0 = Math.Exp(-x2) / (2.0 * x * Math.Sqrt(3.141592653589793));
                return p0;
            }
            // точна формула - розклад в ряд
            s = x;
            for (i = 1; i <= 100; i++)
            {
                x = -x * x2 / i;
                s = s + x / (i + i + 1);
            }
            p0 = 0.5 - s / Math.Sqrt(3.141592653589793);
            return p0;
        }

    }
}
