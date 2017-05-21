using System.Windows.Controls;
using System.Windows.Navigation;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationService.Navigating += OnNavigating;
        }

        private void OnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode.Equals(NavigationMode.Back))
            {
                if (e.Content != null && e.Content is Page)
                {
                    Page content = (Page) e.Content;
                    IListViewModel context = content.DataContext as IListViewModel;
                    if (context != null)
                    {
                        context.RefreshDataSource();
                    }
                }
            }
        }
    }
}