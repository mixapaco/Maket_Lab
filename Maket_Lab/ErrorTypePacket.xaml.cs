using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для ErrorTypePacket.xaml
    /// </summary>
    public partial class ErrorTypePacket : Window
    {
        public WindowsWork.ErrorPassHolder parameters;
        public ErrorTypePacket(WindowsWork.ErrorPassHolder param)
        {
            InitializeComponent();
            parameters = param;

            Dictionary<string, double> buf = new Dictionary<string, double>(12);
            buf.Add("PacketError", float.Parse( (string) ErrPacket.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("ErrorLambda", Double.Parse(ErrBetweenPacket.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("p1", Double.Parse(p1.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("p2", Double.Parse(p2.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("p3", Double.Parse(p3.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("h1", Double.Parse(h1.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("h2", Double.Parse(h2.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("q1", Double.Parse(q1.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("q2", Double.Parse(q2.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("q3", Double.Parse(q3.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("r1", Double.Parse(r1.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("r2", Double.Parse(r2.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            parameters.SetParams(buf);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, double> buf = new Dictionary<string, double>(12);
            buf.Add("PacketError", float.Parse((string)ErrPacket.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("ErrorLambda", Double.Parse(ErrBetweenPacket.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("p1", Double.Parse(p1.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("p2", Double.Parse(p2.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("p3", Double.Parse(p3.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("h1", Double.Parse(h1.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("h2", Double.Parse(h2.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("q1", Double.Parse(q1.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("q2", Double.Parse(q2.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("q3", Double.Parse(q3.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("r1", Double.Parse(r1.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            buf.Add("r2", Double.Parse(r2.Text.Replace(',', '.'), CultureInfo.InvariantCulture));
            parameters.SetParams(buf);
            this.Close();
        }
    }
}
