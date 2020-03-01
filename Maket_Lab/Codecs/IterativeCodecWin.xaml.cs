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

namespace Maket_Lab.Codecs
{
    /// <summary>
    /// Логика взаимодействия для IterativeCodecWin.xaml
    /// </summary>
    public partial class IterativeCodecWin : Window
    {
        public IterativeCodecWin()
        {
            InitializeComponent();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help h = new Help("");
            h.SetMsg("Скоро");
            h.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if(b.Name == "InputButton") 
            {
                FileWork.FileGeter fileGeter = new FileWork.FileGeter();
                
                InputFile.Text = fileGeter.GetFileNameFull();
            }

            if (b.Name == "OutPutButton")
            {
                FileWork.FileGeter fileGeter = new FileWork.FileGeter();

                OutPutFile.Text = fileGeter.GetFileNameFull();
            }
        }
    }
}

