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

namespace Ex8_ResponsiveUI
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

        private void addRow(Grid grid, int numRow)
        {
            RowDefinition newRow;

            for (int i = 0; i < numRow; i++)
            {
                newRow = new RowDefinition();
                newRow.Height = new GridLength(1, GridUnitType.Star); // Establir la mida com proporcional
                grid.RowDefinitions.Add(newRow);
            }
        }

        // Aquest event s'executa quan la mida de la finestra canvia
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Amaga la barra lateral si la finestra és massa petita
            Sidebar.Visibility = e.NewSize.Width < 700 ? Visibility.Collapsed : Visibility.Visible;

            // Reorganitza les caixes en funció de l'amplada
            if (e.NewSize.Width < 700) // Si la finestra és més estreta, distribueix les caixes en una columna
            {
                if(MainContentGrid.RowDefinitions.Count == 4) return; // Si ja està distribuït, no cal fer res
                
                //Distribuïm les caixes en una columna
                addRow(MainContentGrid, 2);
                for (int i = 0; i < MainContentGrid.Children.Count; i++)
                {
                    Grid.SetRow(MainContentGrid.Children[i], i);
                    Grid.SetColumn(MainContentGrid.Children[i], 0);
                    Grid.SetColumnSpan(MainContentGrid.Children[i], 2);
                }
            }
            else // Si la finestra és més ampla, distribueix les caixes en dues columnes
            {
                if (MainContentGrid.RowDefinitions.Count == 2) return; // Si ja està distribuït, no cal fer res

                //Distribuïm les caixes en dos columnes
                MainContentGrid.RowDefinitions.Clear();
                addRow(MainContentGrid, 2);
                for (int i = 0; i < MainContentGrid.Children.Count; i++)
                {
                    Grid.SetRow(MainContentGrid.Children[i], i/2);
                    Grid.SetColumn(MainContentGrid.Children[i], i%2);
                    Grid.SetColumnSpan(MainContentGrid.Children[i], 1);
                }
            }
        }
    }
}