using System.Windows.Controls;
using VinylRecordShop.ViewModels.Genres;

namespace VinylRecordShop.Pages.Genre
{
    /// <summary>
    /// Логика взаимодействия для GenreListPage.xaml
    /// </summary>
    public partial class GenreListPage : Page
    {
        public GenreListPage(): this(new GenreListViewModel())
        {
        }

        public GenreListPage(GenreListViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
