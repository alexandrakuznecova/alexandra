using System.Windows.Input;
using VinylRecordShop.Logic;

namespace VinylRecordShop.ViewModels.Base
{
    public partial class EntityViewModel<T>
    {
        public ICommand CancelCommand
        {
            get { return new DelegateCommand(Cancel); }
        }

        public ICommand SaveCommand
        {
            get { return new DelegateCommand(Save); }
        }

        protected virtual void Cancel()
        {
            NavigationHelper.NavigationService.GoBack();
        }

        protected virtual void Save()
        {
            if (IsValid())
            {
                _entityService.AddOrUpdate(_entity);
                ForceNavigate(GetListPage());
            }
        }
    }
}
