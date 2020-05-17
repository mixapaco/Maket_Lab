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
    /// Логика взаимодействия для ChannelModel.xaml
    /// </summary>
    public partial class ChannelModel : Window
    {
        public WindowsWork.ErrorPassHolder parameters;
        public ChannelModel()
        {
            InitializeComponent();
            parameters = new WindowsWork.ErrorPassHolder();
            ErrorTypeSingle errWin = new ErrorTypeSingle(parameters);
            ErrorTypePacket errWin2 = new ErrorTypePacket(parameters);
            errWin.Close();
            errWin2.Close();
            ErrSingleRadio.IsChecked = true;
        }
        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Error_Click(object sender, RoutedEventArgs e)
        {
            if((bool)ErrSingleRadio.IsChecked)
            {
                ErrorTypeSingle errWin = new ErrorTypeSingle(parameters);
                errWin.Show();
            }
            if((bool)ErrPacketRadio.IsChecked)
            {
                ErrorTypePacket errWin = new ErrorTypePacket(parameters);
                errWin.Show();
            }
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
        private int GetSimetryType()
        {
            if (Sim1.IsChecked == true)
                return 1;
            if (Sim2.IsChecked == true)
                return 2;
            if (Sim3.IsChecked == true)
                return 3;
            return 1;
        }
        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            FileWork.BinFileReader binFileReader = new FileWork.BinFileReader();
            List<bool> bits = binFileReader.ReadFile(InputFile.Text);
            Dictionary<string, double> param =  parameters.GetParams();
            int typeSim = GetSimetryType();
            CodecsWork.ChanelModel chanelModel = new CodecsWork.ChanelModel(typeSim);


            if (ErrSingleRadio.IsChecked == true)
            {
                if (!param.ContainsKey("typeSingle")) 
                {
                    ErrorTypeSingle errWin = new ErrorTypeSingle(parameters);
                    errWin.Close();
                    param = parameters.GetParams(); 
                    chanelModel = new CodecsWork.ChanelModel(typeSim);
                }

                bits = chanelModel.SingleError(bits, param["typeSingle"] == 1 ? param["SingleError"] : param["Noise"], param["typeSingle"] == 1 ? true : false);
            }

            if (ErrPacketRadio.IsChecked == true)
            {
                if (!param.ContainsKey("PacketError"))
                {
                    ErrorTypePacket errWin = new ErrorTypePacket(parameters);
                    errWin.Close();
                    param = parameters.GetParams();
                    chanelModel = new CodecsWork.ChanelModel(typeSim);
                }

                bits = chanelModel.PacketError(bits, param);
            }
            FileWork.BinFileCreator binFileCreator = new FileWork.BinFileCreator();
            binFileCreator.WriteInFile(bits, OutPutFile.Text);
            MessageBox.Show("Готово");
        }
    }
}
