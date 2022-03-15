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
using System.Xml;
using System.Xml.Linq;

namespace Interview
{
    public partial class AddingWindow : Window
    {
       
        public AddingWindow()
        {
            InitializeComponent();
            
           
        }

       private void Apply_click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            XmlWorker worker = new XmlWorker();
            worker.AddToXML(username.Text,surname.Text,phone.Text);
            main.Show();
            this.Hide();
        }

        private void Back_click(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        
    }
}
