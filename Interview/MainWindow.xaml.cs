using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml;
using System.Xml.Linq;

namespace Interview
{
    public partial class MainWindow : Window
    {
        private List<string> _data;
        private List<CustomArray> _user;
        private XmlWorker _worker;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void TakeScreen()
        {
            _worker = new XmlWorker();
            _user = new List<CustomArray>();
            _worker.LoadFromXml(_user);

            foreach (var item in _user)
            {
                box.Items.Add(item);
            }
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TakeScreen();
        }


        private void Person_click(object sender, RoutedEventArgs e)
        {
            AddingWindow window = new AddingWindow();
            window.Show();
            this.Hide();
        }

       

        private void trash_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _worker = new XmlWorker();
                var information = box.SelectedItem;
                string id = _user[box.SelectedIndex].ID;
                if (MessageBox.Show("Do you want to delete this field?",
                    "Attention", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    box.Items.Remove(information);
                   _worker.DeleteFromXml(id);
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Choose element");
            }

        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Field_changed(object sender, TextChangedEventArgs e)
        {

            if (findbox.Text != string.Empty)
            {
                box.Items.Clear();
                foreach (var item in _user)
                {

                    if (item.ID == findbox.Text || item.Name == findbox.Text || item.Surname == findbox.Text || item.Phone == findbox.Text)
                    {
                        box.Items.Add(item);
                    }
                }
            }
            else
            {
                box.Items.Clear();
                TakeScreen();
            }


        }

        private void Change_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
