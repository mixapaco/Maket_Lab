using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Maket_Lab.FileWork
{
    class FileSaver
    {
        public string SaveFile(string fileName = "new_file.bin")
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Filter = "Bin (*.bin)|*.bin|All files(*.*)|*.*";
            if (saveFileDialog.ShowDialog() != null)
                return saveFileDialog.FileName;

            return null;
        }


    }
}
