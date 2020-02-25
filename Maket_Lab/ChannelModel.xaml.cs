﻿using System;
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
        public ChannelModel()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Error_Click(object sender, RoutedEventArgs e)
        {
            if((bool)ErrSingleRadio.IsChecked)
            {
                ErrorTypeSingle errWin = new ErrorTypeSingle();
                errWin.Show();
            }
            if((bool)ErrPacketRadio.IsChecked)
            {
                ErrorTypePacket errWin = new ErrorTypePacket();
                errWin.Show();
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help h = new Help("");
            h.SetMsg("Скоро");
            h.Show();
        }

    }
}