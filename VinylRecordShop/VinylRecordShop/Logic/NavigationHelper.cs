using System.Windows.Navigation;

namespace VinylRecordShop.Logic
{
    public static class NavigationHelper
    {
        private static NavigationService navigator;

        public static NavigationService NavigationService
        {
            set
            {
                navigator = value;
            }
            get
            {
                return navigator;
            }

        }

    }
}
