namespace VinylRecordShop.ViewModels.Home
{
    public partial class HomeViewModel
    {
        private string _welocmeMessage;

        public string WelcomeMessage
        {
            get { return _welocmeMessage; }
            set { _welocmeMessage = value; }
        }

        public HomeViewModel()
        {
            WelcomeMessage = "Добро пожаловать в магазин виниловых пластинок";
        }
    }
}
