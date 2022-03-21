
using System.Windows;
using System.Windows.Input;


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
