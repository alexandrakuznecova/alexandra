namespace VinylRecordShop.ViewModels.Base
{
    public class CountryViewModel
    {

        private string _name;
        private string _code;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
            }
        }
    }
}
