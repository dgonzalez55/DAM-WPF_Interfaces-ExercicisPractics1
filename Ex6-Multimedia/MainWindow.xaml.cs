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

namespace Ex6_Multimedia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Llista d'imatges per a la galeria
        private readonly string[] imagePaths = {
            "Images/image1.jpg",
            "Images/image2.jpg",
            "Images/image3.jpg",
            "Images/image4.jpg"
        };

        // Índex actual de la imatge
        private int currentImageIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            ShowImage(currentImageIndex); // Mostra la primera imatge
        }

        // Canvi de mida de la imatge segons el Slider
        private void ImageSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (GalleryImage != null)
            {
                GalleryImage.Width = e.NewValue;
                GalleryImage.Height = e.NewValue;
            }
        }

        // Mostrar la imatge actual a la galeria
        private void ShowImage(int index)
        {
            if (index >= 0 && index < imagePaths.Length)
            {
                GalleryImage.Source = new BitmapImage(new Uri(imagePaths[index], UriKind.Relative));
            }
        }

        // Navegar a la imatge anterior
        private void PreviousImage_Click(object sender, RoutedEventArgs e)
        {
            currentImageIndex--;
            if (currentImageIndex < 0)
            {
                currentImageIndex = imagePaths.Length - 1; // Torna a l'última imatge si es passa del principi
            }
            ShowImage(currentImageIndex);
        }

        // Navegar a la imatge següent
        private void NextImage_Click(object sender, RoutedEventArgs e)
        {
            currentImageIndex++;
            if (currentImageIndex >= imagePaths.Length)
            {
                currentImageIndex = 0; // Torna a la primera imatge si es passa del final
            }
            ShowImage(currentImageIndex);
        }

        // Reproduir el vídeo
        private void PlayVideo_Click(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Play();
        }

        // Pausar el vídeo
        private void PauseVideo_Click(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Pause();
        }

        // Aturar el vídeo
        private void StopVideo_Click(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Stop();
        }

        private void VideoPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Position = TimeSpan.FromSeconds(1);
            VideoPlayer.Play();
        }
    }
}