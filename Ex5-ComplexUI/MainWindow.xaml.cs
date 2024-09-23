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

namespace Ex5_ComplexUI
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

        // Gestió de l'element seleccionat al ListBox
        private void NavigationList_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
            // Netegem el contingut existent
            MainContent.Children.Clear();

            // Obtenim l'element seleccionat
            ListBox? listBox = sender as ListBox;
            ListBoxItem? selectedItem = listBox?.SelectedItem as ListBoxItem;

            if (selectedItem != null)
            {
                HideSubMenus(selectedItem);
                switch (selectedItem.Tag)
                {
                    case "Home"       : ShowHome();         break;
                    case "Settings"   : ShowSettings();     break;
                    case "Preferences": ShowPreferences();  break;
                    case "Security"   : ShowSecurity();     break;
                    case "About"      : ShowAbout();        break;
                    default           : ShowDefault();      break;
                }
            }
        }

        private void HideSubMenus(ListBoxItem li)
        {
            
            string[] settingsMenu = { "Settings", "Preferences", "Security" };
            if (Array.Exists(settingsMenu, menu => li.Tag.ToString() == menu))
            {
                liSettingsPref.Visibility = Visibility.Visible;
                liSettingsSec.Visibility = Visibility.Visible;
            }
            else
            {
                liSettings.Content = "Configuració   ▶";
                liSettingsPref.Visibility = Visibility.Collapsed;
                liSettingsSec.Visibility = Visibility.Collapsed;
            }
        }

        // Mètodes per a les seccions seleccionades
        private void ShowHome()
        {
            MainContent.Children.Add(new TextBlock
            {
                Text = "Estàs a la pàgina d'Inici.",
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            });
        }

        private void ShowSettings()
        {
            liSettingsPref.Visibility = Visibility.Visible;
            liSettingsSec.Visibility = Visibility.Visible;
            liSettings.Content = "Configuració   ▼";

            MainContent.Children.Add(new TextBlock
            {
                Text = "Configuració general de l'aplicació.",
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            });
        }

        private void ShowPreferences()
        {
            MainContent.Children.Add(new TextBlock
            {
                Text = "Aquesta és la pàgina de Preferències.",
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            });
        }

        private void ShowSecurity()
        {
            MainContent.Children.Add(new TextBlock
            {
                Text = "Aquesta és la pàgina de Seguretat.",
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            });
        }

        private void ShowAbout()
        {
            MainContent.Children.Add(new TextBlock
            {
                Text = "Informació sobre l'aplicació.",
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            });
        }

        private void ShowDefault()
        {
            MainContent.Children.Add(new TextBlock
            {
                Text = "Selecciona una opció per veure més informació.",
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            });
        }
    }
}