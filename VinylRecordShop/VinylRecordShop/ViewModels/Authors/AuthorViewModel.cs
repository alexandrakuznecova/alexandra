using System;
using System.Collections.Generic;
using System.Windows.Controls;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.Pages.Author;
using VinylRecordShop.Services.Services.Implementation;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop.ViewModels.Authors
{
    public class AuthorViewModel : EntityViewModel<Author>
    {

        public AuthorViewModel(int id): base(id , new AuthorService())
        {

        }
        public AuthorViewModel(Author entity): base(entity)
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
        public DateTime BirthDate
        {
            get { return Entity.BirthDate ?? DateTime.Now; }
            set { Entity.BirthDate = value; }
        }

        public List<CountryViewModel> CountryList
        {
            get { return GetCountryList(); }
        }


        protected override Page GetListPage()
        {
            return new AuthorListPage(new AuthorListViewModel());
        }

        protected override void CheckProperties()
        {
            OnPropertyChanged(nameof(Name));
        }

        protected override string Validate(string fieldName)
        {
            string result = null;

            if (fieldName.Equals(nameof(Name)))
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    result = "Поле 'ФИО' является обязательным";
                }


            }
            return result;
        }
    }
}
