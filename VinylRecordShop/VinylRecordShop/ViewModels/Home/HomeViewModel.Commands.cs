using System.Windows.Input;
using VinylRecordShop.Logic;
using VinylRecordShop.Pages.Author;
using VinylRecordShop.Pages.Genre;
using VinylRecordShop.Pages.Publisher;
using VinylRecordShop.ViewModels.Base;
using VinylRecordListPage = VinylRecordShop.Pages.VinylRecord.VinylRecordListPage;

namespace VinylRecordShop.ViewModels.Home
{
    public partial class HomeViewModel :ViewModelBase
    {
        public ICommand ShowVinylRecordListCommand
        {
            get { return new DelegateCommand(ShowVinylRecordList); }
        }

        public ICommand ShowAuthorListCommand
        {
            get { return new DelegateCommand(ShowAuthorList); }
        }

        public ICommand ShowPublisherListCommand
        {
            get { return new DelegateCommand(ShowPublisherList); }
        }

        public ICommand ShowGenreListCommand
        {
            get { return new DelegateCommand(ShowGenreList); }
        }

        private void ShowPublisherList()
        {
            Navigate(new PublisherListPage());
        }

        private void ShowAuthorList()
        {
            Navigate(new AuthorListPage());
        }

        private void ShowVinylRecordList()
        {
            var page = new VinylRecordListPage();
            Navigate(page);
        }

        private void ShowGenreList()
        {
            var page = new GenreListPage();
            Navigate(page);
        }
    }
}