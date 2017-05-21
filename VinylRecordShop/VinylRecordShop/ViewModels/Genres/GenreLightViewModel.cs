using System.Windows.Controls;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop.ViewModels.Genres
{
    public class GenreLightViewModel : EntityViewModel<Genre>
    {
        public GenreLightViewModel(Genre genre) : base(genre)
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
