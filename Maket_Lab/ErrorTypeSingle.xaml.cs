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
    /// Логика взаимодействия для ErrorTypeSingle.xaml
    /// </summary>
    public partial class ErrorTypeSingle : Window
    {
        public WindowsWork.ErrorPassHolder parameters;
        public ErrorTypeSingle(WindowsWork.ErrorPassHolder param)
        {
            InitializeComponent();
            parameters = param;
            parameters.SetParams(new Dictionary<string, double>() { ["SingleError"] = Double.Parse(ProbError.Text.Replace(',', '.'), CultureInfo.InvariantCulture), ["Noise"] = Double.Parse(Noise.Text.Replace(',', '.'), CultureInfo.InvariantCulture), ["typeSingle"] = Double.Parse(((ProbCheck.IsChecked == true) ? "1.0" : "0.0").Replace(',', '.'), CultureInfo.InvariantCulture) });
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parameters.SetParams(new Dictionary<string, double> { ["SingleError"]= Double.Parse(ProbError.Text.Replace(',', '.'), CultureInfo.InvariantCulture), ["Noise"] = Double.Parse(Noise.Text.Replace(',', '.'), CultureInfo.InvariantCulture) , ["typeSingle"] = Double.Parse(((ProbCheck.IsChecked == true) ? "1.0" : "0.0").Replace(',', '.'), CultureInfo.InvariantCulture) });
            this.Close();
        }
    }
}
