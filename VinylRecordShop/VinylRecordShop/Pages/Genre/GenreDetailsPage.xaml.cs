using System.Windows.Controls;
using VinylRecordShop.ViewModels.Genres;

namespace VinylRecordShop.Pages.Genre
{
    /// <summary>
    /// Логика взаимодействия для GenreDetailsPage.xaml
    /// </summary>
    public partial class GenreDetailsPage : Page
    {
        public GenreDetailsPage()
        {
            InitializeComponent();
        }

        public GenreDetailsPage(GenreViewModel genreViewModel)
        {
            InitializeComponent();
            DataContext = genreViewModel;
        }
    }
}
