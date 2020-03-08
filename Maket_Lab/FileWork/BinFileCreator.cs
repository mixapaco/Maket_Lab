using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Maket_Lab.FileWork
{
    class BinFileCreator
    {
        public bool CreateFile(string filePath = "new_file.bin" , int bitsToWrite = 100 , bool bit =true)
        {
            int i = 0;
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    while (i < bitsToWrite)
                    {
                        writer.Write(bit);
                        i++;
                    }

                }
            }
            catch 
            {
                return false;
            }
            return true;
        }

        public bool WriteInFile(List<bool> bits , string filePath = "new_file.bin" )
        {
            int i = 0;
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    while (i < bits.Count)
                    {
                        writer.Write(bits[i]);
                        i++;
                    }

                }
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
