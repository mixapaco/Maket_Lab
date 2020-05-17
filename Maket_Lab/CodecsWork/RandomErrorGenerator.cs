using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.CodecsWork
{
    class RandomErrorGenerator
    {
        static public double GenerateErrorPercent(Random random)
        {
            double buf = random.NextDouble();
            return buf;
        }

    }
}
