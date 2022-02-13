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
    /// <summary>
    /// Логика взаимодействия для AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
       private XmlDocument _xd;
        public AddingWindow()
        {
            InitializeComponent();

        }

        private string GetLastID()
        {
            var xdoc = XDocument.Load("XMLFile1.xml");
            var lastelement= xdoc.Root.Elements("user").Last();
            var value = int.Parse(lastelement.Attribute("ID").Value)+1;
            return value.ToString();
              
        }
        private void AddToXML()
        {
            _xd = new XmlDocument();
            _xd.Load("XMLFile1.xml");
            XmlNode nl = _xd.SelectSingleNode("users");
            XmlDocument xd2 = new XmlDocument();
            xd2.LoadXml("<user ID='"+GetLastID()+"'><name>" + nametxt.Text + "</name><surname>" + surtxt.Text + "</surname><phone>" + phontxt.Text + "</phone></user>");
            XmlNode n = _xd.ImportNode(xd2.FirstChild, true);
            nl.AppendChild(n);
            _xd.Save("XMLFile1.xml");
        }

       private void Apply_click(object sender, RoutedEventArgs e)
        {
            AddToXML();
        }

        private void Back_click(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
