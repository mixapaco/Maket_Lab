using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Maket_Lab
{
    /// <summary>
    /// Логика взаимодействия для CreateFileWin.xaml
    /// </summary>
    public partial class CreateFileWin : Window
    {
        public CreateFileWin()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help h = new Help("");
            h.SetMsg("Перевірка");
            h.Show();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            bool bit = true;
            string fileName = "new_file.bin";
            Int32 numBits = 100;

            FileWork.FileSaver fileSaver = new FileWork.FileSaver();
            string filePath = fileSaver.SaveFile(fileName);
            if (!String.IsNullOrEmpty(filePath))
                fileName = filePath;
            else
            {
                MessageBox.Show("Не вірний шлях до файлу");
                return;
            }

            if((bool)BitsTypeZero.IsChecked)
            {
                bit = false;
            }

            if (!String.IsNullOrEmpty(FileSizeBox.Text))
            {
                numBits = Convert.ToInt32(FileSizeBox.Text);
            }

            FileWork.BinFileCreator fileCreator = new FileWork.BinFileCreator();
            if (fileCreator.CreateFile(fileName, numBits, bit)) 
            {
                MessageBox.Show("Готово");
            }
            else
            {
                MessageBox.Show("Не вдалося створити файл");
            }
            
        }
    }
}
