using System;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop.ViewModels.VinylRecords
{
    public class VinylRecordFilterViewModel : ViewModelBase , IFilterViewModel<VinylRecord>
    {
        private string _name;
        private string _releaseYear;
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

        public string ReleaseYear
        {
            get
            {
                return _releaseYear;
            }
            set
            {
                _releaseYear = value;
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

        public bool Filter(VinylRecord enity)
        {
            bool accepted = true;

            if (!string.IsNullOrWhiteSpace(Name))
            {
                accepted = enity.Name.Contains(Name);
            }
            if (!string.IsNullOrWhiteSpace(ReleaseYear))
            {
                accepted = enity.Name.Contains(ReleaseYear);
            }
            return accepted;
        }

    }
}