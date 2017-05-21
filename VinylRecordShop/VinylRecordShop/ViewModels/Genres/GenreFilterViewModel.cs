using System;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop.ViewModels.Genres
{
    public class GenreFilterViewModel : ViewModelBase , IFilterViewModel<Genre>
    {
        private string _name;
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

        protected virtual void OnFilterChanged()
        {
            if (FilterChanged != null)
            {
                FilterChanged(this, new EventArgs());
            }
        }

        public bool Filter(Genre enity)
        {
            bool accepted = true;

            if (!string.IsNullOrWhiteSpace(Name))
            {
                accepted = enity.Name.Contains(Name);
            }
            return accepted;
        }

    }
}