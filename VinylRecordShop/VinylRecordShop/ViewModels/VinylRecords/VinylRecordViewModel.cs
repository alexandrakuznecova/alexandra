using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.Logic.Enums;
using VinylRecordShop.Pages.VinylRecord;
using VinylRecordShop.Services.Services.Implementation;
using VinylRecordShop.ViewModels.Authors;
using VinylRecordShop.ViewModels.Base;
using VinylRecordShop.ViewModels.Genres;
using VinylRecordShop.ViewModels.Publishers;

namespace VinylRecordShop.ViewModels.VinylRecords
{
    public class VinylRecordViewModel : EntityViewModel<VinylRecord>
    {
        private readonly AuthorService _authorService = new AuthorService();
        private readonly PublisherService _publisherService = new PublisherService();
        private readonly GenreService _genreService = new GenreService();

        public VinylRecordViewModel(int id) : base(id, new VinylRecordService())
        {
        }

        public VinylRecordViewModel(VinylRecord entity) : base(entity)
        {
        }

        public string Name
        {
            get { return Entity.Name; }
            set
            {
                Entity.Name = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<VinylType> VinylTypes
        {
            get
            {
                return Enum.GetValues(typeof(VinylType))
                    .Cast<VinylType>();
            }
        }

        public string Description
        {
            get { return Entity.Description; }
            set
            {
                Entity.Description = value;
                OnPropertyChanged();
            }
        }

        public string CountryCode
        {
            get { return Entity.CountryCode; }
            set
            {
                Entity.CountryCode = value;
                OnPropertyChanged();
            }
        }

        public string CountryName
        {
            get { return GetCountryName(Entity.CountryCode); }
        }

        public short? ReleaseYear
        {
            get { return Entity.ReleaseYear; }
            set
            {
                Entity.ReleaseYear = value;
                OnPropertyChanged();
            }
        }

        public int Cost
        {
            get { return Entity.Cost; }
            set
            {
                Entity.Cost = value;
                OnPropertyChanged();
            }
        }

        public VinylType VinylType
        {
            get { return (VinylType) Entity.VinylType; }
            set
            {
                Entity.VinylType = (short) value;
                OnPropertyChanged();
            }
        }
        public string VinylTypeName
        {
            get { return VinylType.GetDisplayName(); }
        }

        public int GenreId
        {
            get { return Entity.GenreId ?? 0; }
            set
            {
                Entity.GenreId = value;
                OnPropertyChanged();
            }
        }

        public int AuthorId
        {
            get { return Entity.AuthorId ?? 0; }
            set
            {
                Entity.AuthorId = value;
                OnPropertyChanged();
            }
        }

        public int PublisherId
        {
            get { return Entity.PublisherId ?? 0; }
            set
            {
                Entity.PublisherId = value;
                OnPropertyChanged();
            }
        }

        public string AuthorName
        {
            get { return Entity.Author != null ? Entity.Author.Name : string.Empty; }
        }

        public string PublisherName
        {
            get { return Entity.Publisher != null ? Entity.Publisher.Name : string.Empty; }
        }

        public List<AuthorLightViewModel> AuthorList
        {
            get { return _authorService.GetAll().Select(a => new AuthorLightViewModel(a)).ToList(); }
        }

        public List<PublisherLightViewModel> PublisherList
        {
            get { return _publisherService.GetAll().Select(p => new PublisherLightViewModel(p)).ToList(); }
        }

        public List<GenreLightViewModel> GenreList
        {
            get { return _genreService.GetAll().Select(p => new GenreLightViewModel(p)).ToList(); }
        }

        public List<CountryViewModel> CountryList
        {
            get { return GetCountryList(); }
        }

        protected override Page GetListPage()
        {
            return new VinylRecordListPage(new VinylRecordListViewModel());
        }

        protected override void CheckProperties()
        {
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(ReleaseYear));
            OnPropertyChanged(nameof(Cost));
        }

        protected override string Validate(string fieldName)
        {
            string result = string.Empty;

            switch (fieldName)
            {
                case "Name":

                    if (string.IsNullOrWhiteSpace(Name))
                    {
                        result = "Поле 'Название' является обязательным";
                    }
                    break;
                case "ReleaseYear":
                    int minDate = 1800;
                    int maxDate = DateTime.Now.Year;
                    if (ReleaseYear == null)
                    {
                        result = "Поле 'Год выпуска' является обязательным";
                    }
                    if (ReleaseYear < minDate || ReleaseYear > maxDate)
                    {
                        result = string.Format("Поле 'Год выпуска' не может быть меньше {0} и больше {1}", minDate,
                            maxDate);
                    }
                    break;
                case "Cost":
                    if (Cost <= 0)
                    {
                        result = "Поле 'Цена' должно быть больше 0";
                    }
                    break;
            }
            return result;
        }
    }
}