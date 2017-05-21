using VinylRecordShop.ViewModels.Authors;

namespace VinylRecordShop.Pages.Author
{
    /// <summary>
    /// Логика взаимодействия для AuthorDetailsPage.xaml
    /// </summary>
    public partial class AuthorDetailsPage
    {
        public AuthorDetailsPage()
        {
            InitializeComponent();
        }
        public AuthorDetailsPage(AuthorViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
