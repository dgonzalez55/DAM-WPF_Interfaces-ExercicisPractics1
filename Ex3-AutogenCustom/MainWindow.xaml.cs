using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ex3_AutogenCustom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _labelOriginalContent = "No em toquis els butons!";
        public MainWindow()
        {
            InitializeComponent();
            label1.Content = _labelOriginalContent; 
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = "Hello World!";
            button2.IsEnabled = false;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a Custom Message!");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = _labelOriginalContent;
            button2.IsEnabled = true;
        }
    }
}