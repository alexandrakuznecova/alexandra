using System.Windows.Controls;
using VinylRecordShop.ViewModels.Home;

namespace VinylRecordShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }
    }
}
