using System.Windows.Controls;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.Pages.Genre;
using VinylRecordShop.Services.Services.Implementation;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop.ViewModels.Genres
{
    public class GenreListViewModel : ListViewModelBase<Genre>
    {
        public GenreListViewModel() : base(new GenreService())
        {
            DataGridFilterViewModel = new GenreFilterViewModel();
        }

        protected override Page GetDetailPage(int entityId = 0)
        {
            return new GenreDetailsPage(new GenreViewModel(entityId));
        }

        protected override EntityViewModel<Genre> Map(Genre entity)
        {
            return new GenreViewModel(entity);
        }
    }
}
