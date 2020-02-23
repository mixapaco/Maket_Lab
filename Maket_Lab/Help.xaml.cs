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
    /// Логика взаимодействия для Help.xaml
    /// </summary>
    
    public partial class Help : Window
    {
        private String msg;
        public Help(String text)
        {

            InitializeComponent();
            SetMsg(text);
            
        }

        private void ChangeBoxText()
        {
            TextBoxName.Text = msg;
        }
        public void SetMsg(String text) 
        {
            this.msg = text;
            ChangeBoxText();
        }

    }
}
