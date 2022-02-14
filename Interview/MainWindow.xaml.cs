﻿using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> _data;
        private List<CustomArray> user;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void LoadFromXml()
        {
            user = new List<CustomArray>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("XMLFile1.xml");
            XmlElement? xRoot = xDoc.DocumentElement;

            foreach (XmlElement xnode in xRoot)
            {
                user.Add(new CustomArray { ID = xnode.Attributes.GetNamedItem("ID").Value, Name = xnode.ChildNodes.Item(0).InnerText.Trim(), Surname = xnode.ChildNodes.Item(1).InnerText.Trim(), Phone = xnode.ChildNodes.Item(2).InnerText.Trim() });
            }

        }
        private void TakeScreen()
        {
            LoadFromXml();

            foreach (var item in user)
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

        private void DeleteFromXml(string id)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("XMLFile1.xml");
            XmlElement? xRoot = xDoc.DocumentElement;
            foreach (XmlElement item in xRoot)
            {
                if (item.Attributes.GetNamedItem("ID").Value == id)
                {
                    xRoot.RemoveChild(item);
                }
            }
            xDoc.Save("XMLFile1.xml");

        }

        private void trash_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var information = box.SelectedItem;
                string id = user[box.SelectedIndex].ID;
                if (MessageBox.Show("Do you want to delete this field?",
                    "Attention", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    box.Items.Remove(information);
                    DeleteFromXml(id);
                }
                else
                {
                    
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
                foreach (var item in user)
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
