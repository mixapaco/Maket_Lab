using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Maket_Lab.FileWork
{
    class BinFileReader
    {
        public List<bool> ReadFile(string path)
        {
            List<bool> bits = new List<bool>();
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        bits.Add(reader.ReadBoolean());

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return bits;
        }

    }
}
