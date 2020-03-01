using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Maket_Lab.FileWork
{
    class FileGeter
    {

        public OpenFileDialog GetFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                return openFileDialog;
            return null;
        }
        public string GetFileNameFull()
        {
            OpenFileDialog openFileDialog = GetFile();
            
            if(openFileDialog != null)
                return openFileDialog.FileName;
            return "";
        }
    }

    
}
