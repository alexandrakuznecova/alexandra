using System;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop.ViewModels.Authors
{
    public class AuthorFilterViewModel : ViewModelBase , IFilterViewModel<Author>
    {
        private string _name;
        private string _countryCode;
        public event EventHandler FilterChanged;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnFilterChanged();
            }
        }

        public string CountryCode
        {
            get
            {
                return _countryCode;
            }
            set
            {
                _countryCode = value;
                OnFilterChanged();
            }
        }


        protected virtual void OnFilterChanged()
        {
            if (FilterChanged != null)
            {
                FilterChanged(this, new EventArgs());
            }
        }

        public bool Filter(Author enity)
        {
            bool accepted = true;

            if (!string.IsNullOrWhiteSpace(Name))
            {
                accepted = enity.Name.Contains(Name);
            }
            if (!string.IsNullOrWhiteSpace(CountryCode))
            {
                accepted = enity.CountryCode.Contains(CountryCode);
            }
            return accepted;
        }

    }
}