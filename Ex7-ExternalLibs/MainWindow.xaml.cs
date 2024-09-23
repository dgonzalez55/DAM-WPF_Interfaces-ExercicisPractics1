using LiveCharts.Wpf;
using LiveCharts;
using System.Windows;


namespace Ex7_ExternalLibs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChartValues<double> LineSeriesValues { get; set; }
        public ChartValues<double> BarSeriesValues { get; set; }
        private bool _isInitialized = false;

        public MainWindow()
        {
            InitializeComponent();

            // Dades inicials per a la sèrie de línies i barres
            LineSeriesValues = new ChartValues<double> { 4, 6, 5, 2, 7 };
            BarSeriesValues  = new ChartValues<double> { 3, 5, 6, 2, 8 };
        }

        // Mètode per inicialitzar el gràfic quan la finestra està completament carregada
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Inicialització del gràfic de línies per defecte
            var lineSeries = new LineSeries
            {
                Title = "Dades de Línies",
                Values = LineSeriesValues
            };

            // Afegir la sèrie de línies inicial
            MyChart.Series.Add(lineSeries);

            // Indicar que la finestra està completament carregada
            _isInitialized = true;
        }

        // Event que es dispara quan l'usuari canvia el tipus de gràfic
        private void ChartTypeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Evitar que l'event s'executi si la finestra no està completament inicialitzada
            if (!_isInitialized || MyChart == null)
                return;

            var selectedItem = ChartTypeComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem;

            if (selectedItem != null)
            {
                string? chartType = selectedItem.Content.ToString();

                // Netejar sèries de dades existents
                MyChart.Series.Clear();

                if (chartType == "Gràfic de Línies")
                {
                    // Mostrar el gràfic de línies
                    var lineSeries = new LineSeries
                    {
                        Title = "Dades de Línies",
                        Values = LineSeriesValues
                    };
                    MyChart.Series.Add(lineSeries);
                }
                else if (chartType == "Gràfic de Barres")
                {
                    // Mostrar el gràfic de barres
                    var barSeries = new ColumnSeries
                    {
                        Title = "Dades de Barres",
                        Values = BarSeriesValues
                    };
                    MyChart.Series.Add(barSeries);
                }
            }
        }
    }
}