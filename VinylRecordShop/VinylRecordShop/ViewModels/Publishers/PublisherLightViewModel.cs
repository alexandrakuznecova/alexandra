using System.Windows.Controls;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop.ViewModels.Publishers
{
    public class PublisherLightViewModel : EntityViewModel<Publisher>
    {
        public PublisherLightViewModel(Publisher publisher) : base(publisher)
        {
        }

        public string Name => Entity.Name;

        public int Id => Entity.Id;

        protected override Page GetListPage()
        {
            return null;
        }

        protected override void CheckProperties()
        {
            //
        }

        protected override string Validate(string fieldName)
        {
            return null;
        }
    }
}