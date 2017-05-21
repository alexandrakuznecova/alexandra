using System.Windows.Controls;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.Pages.Author;
using VinylRecordShop.Services.Services.Implementation;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop.ViewModels.Authors
{
    public class AuthorListViewModel : ListViewModelBase<Author>
    {
        public AuthorListViewModel() : base(new AuthorService())
        {
            DataGridFilterViewModel = new AuthorFilterViewModel();
        }

        protected override Page GetDetailPage(int entityId = 0)
        {
            return new AuthorDetailsPage(new AuthorViewModel(entityId));
        }

        protected override EntityViewModel<Author> Map(Author entity)
        {
            return new AuthorViewModel(entity);
        }
    }
}
