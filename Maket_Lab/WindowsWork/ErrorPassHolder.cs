using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maket_Lab.WindowsWork
{
    public class ErrorPassHolder
    {
        private Dictionary<string, double> parametrs;

        public ErrorPassHolder()
        {

        }

        public void SetParams(Dictionary<string, double> par)
        {
            parametrs = par;
        }

        public Dictionary<string, double> GetParams()
        {
            return parametrs;
        }

    }
}
