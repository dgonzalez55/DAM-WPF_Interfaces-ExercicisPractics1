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

namespace Ex4_DynamicForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            radioEmpresa.IsChecked = true;
        }

        private void resetFields()
        {
            textBoxID.Clear();
            textBoxName.Clear();
            checkFilledFields();
        }

        private void checkFilledFields()
        {
            bool isNameFilled = textBoxName.Text.Length > 0;
            bool isIDFilled = textBoxID.Text.Length > 0;
            errorName.Visibility = isNameFilled ? Visibility.Collapsed : Visibility.Visible;
            errorID.Visibility = isIDFilled ? Visibility.Collapsed : Visibility.Visible;
            buttonSubmit.IsEnabled = isNameFilled && isIDFilled;
        }

        private void radioEmpresa_Checked(object sender, RoutedEventArgs e)
        {
            labelName.Content = "Nom de l'Empresa:";
            labelID.Content = "CIF:";
            resetFields();
        }

        private void radioPersona_Checked(object sender, RoutedEventArgs e)
        {
            labelName.Content = "Nom:";
            labelID.Content = "DNI:";
            resetFields();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Formulari enviat correctament!");
            resetFields();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkFilledFields();
        }
    }
}