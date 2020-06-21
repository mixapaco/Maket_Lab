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
    /// Логика взаимодействия для ShufleFileWin.xaml
    /// </summary>
    public partial class ShuffleFileWin : Window
    {
        public ShuffleFileWin()
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
            h.SetMsg("Скоро");
            h.Show();
        }
        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b.Name == "InputButton")
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
        private void Exec_Click(object sender, RoutedEventArgs e)
        {
            FileWork.BinFileReader binFileReader = new FileWork.BinFileReader();
            List<bool> bits = binFileReader.ReadFile(InputFile.Text);
            Int32 row = getRow();
            Int32 column = getColumn();

            bits = BinWork.Shufle.ShufleBits(bits , row , column);

            FileWork.BinFileCreator binFileCreator = new FileWork.BinFileCreator();
            binFileCreator.WriteInFile(bits, OutPutFile.Text);
            MessageBox.Show("Готово");

        }
        private int getRow()
        {
            int row = 1;
            if(ShufleRadio.IsChecked == true)
                row = Int32.Parse(((TextBlock)((ComboBoxItem)Row.SelectedItem).Content).Text);
            else
                row = Int32.Parse(((TextBlock)((ComboBoxItem)Column.SelectedItem).Content).Text);
            return row;
        }

        private int getColumn()
        {
            int column = 1;
            if (ShufleRadio.IsChecked == true)
                column = Int32.Parse(((TextBlock)((ComboBoxItem)Column.SelectedItem).Content).Text);
            else
                column = Int32.Parse(((TextBlock)((ComboBoxItem)Row.SelectedItem).Content).Text);
            return column;
        }
    }
}
