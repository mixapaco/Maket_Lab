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

namespace Maket_Lab.Showing
{
    /// <summary>
    /// Логика взаимодействия для PacketErrorView.xaml
    /// </summary>
    public partial class PacketErrorView : Window
    {
        public PacketErrorView()
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
        private void Exec_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b.Name == "Code" || b.Name == "Decode")
            {
                CodecSelect codecSelect = new CodecSelect();
                codecSelect.Show();
            }
            if (b.Name == "Shufle" || b.Name == "Restore")
            {
                ShuffleFileWin win = new ShuffleFileWin();
                win.Show();
            }
            if (b.Name == "InFile")
            {
                CreateFileWin createFileWin = new CreateFileWin();
                createFileWin.Show();
            }
            if (b.Name == "Channel")
            {
                ChannelModel channelModel = new ChannelModel();
                channelModel.Show();
            }
        }

    }
}
