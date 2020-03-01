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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Maket_Lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            About AboutWindow = new About();
            AboutWindow.Show();
        }

        private void TestFile_Click(object sender, RoutedEventArgs e)
        {
            CreateFileWin CreateFileWindow = new CreateFileWin();
            CreateFileWindow.Show();
        }

        private void ChanellModel_Click(object sender, RoutedEventArgs e)
        {
            ChannelModel channelModel = new ChannelModel();
            channelModel.Show();
        }
        private void Shuffle_Click(object sender, RoutedEventArgs e)
        {
            ShuffleFileWin shuffleFileWin = new ShuffleFileWin();
            shuffleFileWin.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Viterbi_Click(object sender, RoutedEventArgs e)
        {
            Codecs.VeterbiCodecWin veterbiCodecWin = new Codecs.VeterbiCodecWin();
            veterbiCodecWin.Show();

        }

        private void Iterative_Click(object sender, RoutedEventArgs e)
        {
            Codecs.IterativeCodecWin iterativeCodecWin = new Codecs.IterativeCodecWin();
            iterativeCodecWin.Show();
        }

        private void BCH_Click(object sender, RoutedEventArgs e)
        {
            Codecs.BCHCodecWin codecWin = new Codecs.BCHCodecWin();
            codecWin.Show();
        }

        private void Loop_Click(object sender, RoutedEventArgs e)
        {
            Codecs.LoopCodecWin loopCodecWin = new Codecs.LoopCodecWin();
            loopCodecWin.Show();
        }
    }
}
