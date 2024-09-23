using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ex2_AdvancedThemes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _isDarkTheme = false;
        public MainWindow()
        {
            InitializeComponent();
            // Carreguem el tema clar per defecte
            ChangeTheme("./Themes/TemaClar.xaml");
        }

        private void buttonToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            if (_isDarkTheme)
            {
                ChangeTheme("./Themes/TemaClar.xaml");
                buttonToggleTheme.Content = "Tema Fosc";
            }
            else
            {
                ChangeTheme("./Themes/TemaFosc.xaml");
                buttonToggleTheme.Content = "Tema Clar";
            }
            _isDarkTheme = !_isDarkTheme;
            // Restablim els valors per defecte del tema (l'usuari els pot haver modificat via UI)
            RestoreDefaultThemeValues();
        }

        private void RestoreDefaultThemeValues()
        {
            // Recuperem els valors originals del tema
            var backgroundColor = App.Current.Resources.MergedDictionaries[0]["ButtonBackgroundColor"];
            var fontSize = App.Current.Resources.MergedDictionaries[0]["ButtonFontSize"];
            App.Current.Resources["ButtonBackgroundColor"] = backgroundColor;
            App.Current.Resources["ButtonFontSize"] = fontSize;

            // Eliminem la selecció dels combobox (hem restablert el tema, per tant, no hi ha cap selecció)
            colorPicker.SelectedIndex = -1;
            fontSizePicker.SelectedIndex = -1;
        }

        private void ChangeTheme(string themePath)
        {
            // Netegem els diccionaris de recursos actuals
            App.Current.Resources.MergedDictionaries.Clear();

            // Carreguem el diccionari de recursos corresponent
            var themeDictionary = new ResourceDictionary() { Source = new Uri(themePath, UriKind.Relative) };
            App.Current.Resources.MergedDictionaries.Add(themeDictionary);

            // Reapliquem l'estil de la finestra manualment després de canviar el tema (no s'aplica automàticament)
            var windowStyle = App.Current.TryFindResource(typeof(Window)) as Style;
            if (windowStyle != null)
            {
                this.Style = windowStyle;
            }
        }
        private void colorPicker_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox? comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedIndex > -1)
            {
                string? selectedColor = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                // Actualitzem el recurs global per al color de fons dels botons
                App.Current.Resources["ButtonBackgroundColor"] = new BrushConverter().ConvertFromString(selectedColor ?? "#FFFFFF") as Brush;
            }

        }
        private void fontSizePicker_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox? comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedIndex > -1)
            {

                string? selectedFontSize = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                // Actualitzem el recurs global per a la mida de la font dels botons
                App.Current.Resources["ButtonFontSize"] = double.Parse(selectedFontSize ?? "12");
            }
        }
    }
}