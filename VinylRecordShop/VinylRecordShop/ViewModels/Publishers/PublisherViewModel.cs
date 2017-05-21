using System.Windows.Controls;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.Pages.Publisher;
using VinylRecordShop.Services.Services.Implementation;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop.ViewModels.Publishers
{
    public class PublisherViewModel : EntityViewModel<Publisher>
    {
        public PublisherViewModel(int id): base(id , new PublisherService())
        {

        }

        public PublisherViewModel(Publisher entity) : base(entity)
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

        protected override Page GetListPage()
        {
            return new PublisherListPage();
        }

        protected override void CheckProperties()
        {
            OnPropertyChanged(nameof(Name));
        }

        protected override string Validate(string fieldName)
        {
            if (fieldName.Equals(nameof(Name)))
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    return "Поле 'Название' является обязательным";
                }
            }
            return null;
        }
    }
}