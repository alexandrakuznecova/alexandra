using System.Windows.Controls;
using VinylRecordShop.ViewModels.VinylRecords;

namespace VinylRecordShop.Pages.VinylRecord
{
    /// <summary>
    /// Логика взаимодействия для VinylRecordListPage.xaml
    /// </summary>
    public partial class VinylRecordListPage : Page
    {
        public VinylRecordListPage() : this(new VinylRecordListViewModel())
        {
        }

        public VinylRecordListPage(VinylRecordListViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
