using System.Windows.Controls;
using VinylRecordShop.ViewModels.Publishers;

namespace VinylRecordShop.Pages.Publisher
{
    /// <summary>
    /// Interaction logic for PublisherListPage.xaml
    /// </summary>
    public partial class PublisherListPage : Page
    {
        public PublisherListPage() : this(new PublisherListViewModel())
        {
        }

        public PublisherListPage(PublisherListViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
