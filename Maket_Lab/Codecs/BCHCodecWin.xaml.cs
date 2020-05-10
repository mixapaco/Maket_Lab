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
    /// Логика взаимодействия для BCHCodecWin.xaml
    /// </summary>
    public partial class BCHCodecWin : Window
    {
        public BCHCodecWin()
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

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            Int32 m = Int32.Parse(((TextBlock)((ComboBoxItem)M.SelectedItem).Content).Text);
            Int32 Tmin = Int32.Parse(((TextBlock)((ComboBoxItem)TСorrect.SelectedItem).Content).Text);
            CodecsWork.BCHCodec codec = new CodecsWork.BCHCodec(m,Tmin);
            Polinom.Text = BinWork.BinWorker.ToString(codec.CreatePolinom());
            n.Text = codec.N.ToString();
            r.Text = codec.R.ToString();
            k.Text = codec.K.ToString();
             
        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            FileWork.BinFileReader binFileReader = new FileWork.BinFileReader();
            List<bool> bits = binFileReader.ReadFile(InputFile.Text);

            Int32 Tmin = Int32.Parse(((TextBlock)((ComboBoxItem)TСorrect.SelectedItem).Content).Text);
            CodecsWork.LoopCodec loopCodec = new CodecsWork.LoopCodec(Polinom.Text, Int32.Parse(r.Text), Int32.Parse(k.Text), Tmin);
            if (CodeRadio.IsChecked == true)
                bits = loopCodec.CodeLineBits(bits);
            else
                bits = loopCodec.DeCodeLineBits(bits);

            FileWork.BinFileCreator binFileCreator = new FileWork.BinFileCreator();
            binFileCreator.WriteInFile(bits, OutPutFile.Text);
        }
    }
}
