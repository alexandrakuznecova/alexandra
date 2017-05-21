using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using VinylRecordShop.Logic;

namespace VinylRecordShop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Navigated += App_Navigated;
        }

        void App_Navigated(object sender, NavigationEventArgs e)
        {
            Page page = e.Content as Page;
            if (page != null)
                NavigationHelper.NavigationService = page.NavigationService;
        }
    }

}
