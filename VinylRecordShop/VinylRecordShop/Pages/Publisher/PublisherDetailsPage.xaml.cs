using System.Windows.Controls;
using VinylRecordShop.ViewModels.Publishers;

namespace VinylRecordShop.Pages.Publisher
{
    /// <summary>
    /// Interaction logic for PublisherDetailsPage.xaml
    /// </summary>
    public partial class PublisherDetailsPage : Page
    {
        public PublisherDetailsPage()
        {
            InitializeComponent();
        }

        public PublisherDetailsPage(PublisherViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
