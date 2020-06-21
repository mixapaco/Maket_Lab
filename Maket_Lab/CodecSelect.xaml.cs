using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для CodecSelect.xaml
    /// </summary>
    public partial class CodecSelect : Window
    {
        public CodecSelect()
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
            try
            {
                Window view = (Window)GetInstance(b.Name);
                view.Show();
            }
            catch(ArgumentException err)
            {
                MessageBox.Show("Помилка з вибором кодера!");
            }
        }
        public object GetInstance(string strFullyQualifiedName)
        {
            var classType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name == strFullyQualifiedName);
            if (classType == null)
                throw new ArgumentException();
            Type t = Type.GetType(classType.AssemblyQualifiedName);
            return Activator.CreateInstance(t);
        }
    }
}
