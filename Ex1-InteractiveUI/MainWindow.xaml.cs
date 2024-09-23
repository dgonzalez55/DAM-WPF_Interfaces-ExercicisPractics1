using System.Windows;

namespace Ex1_InteractiveUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string msgExtra = checkBox1.IsChecked == true ? "activat" : "desactivat";
            MessageBox.Show($"Botó 1 premut i checkbox {msgExtra}");
        }

        private void checkBox1_StatusChanged(object sender, RoutedEventArgs e)
        {
            button1.Content = checkBox1.IsChecked == true ? "Botó 1" : "Button1";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if(checkBox1.IsChecked == true)
            {
                int currentVal = int.Parse(label1.Content.ToString().Replace("Comptador: ", ""));
                label1.Content = $"Comptador: {currentVal + 1}";
            }
            else
            {
                MessageBox.Show("El comptador no es pot actualitzar sense marcar el checkbox");
            }
        }
    }
}