using System;
using System.Windows.Input;
using VinylRecordShop.Logic;

namespace VinylRecordShop.ViewModels.Base
{
    public partial class ListViewModelBase<T>
    {
        public ICommand AddCommand
        {
            get { return new DelegateCommand(Add); }
        }

        public ICommand EditCommand
        {
            get { return new DelegateCommand(Edit); }
        }

        public ICommand DeleteCommand
        {
            get { return new DelegateCommand(Delete); }
        }
        public ICommand RefreshCommand
        {
            get { return new DelegateCommand(Refresh); }
        }

        private void Add()
        {
            Navigate(GetDetailPage());
        }

        private void Edit()
        {
            if (SelectedItem == null)
            {
                throw new NullReferenceException("Элемент не выбран. Редактирование невозможно");
            }
            Navigate(GetDetailPage(SelectedItem.Entity.Id));
        }

        private void Delete()
        {
            if (SelectedItem == null)
            {
                throw new NullReferenceException("Элемент не выбран. Удаление невозможно");
            }
            _entityService.Delete(SelectedItem.Entity);
            SelectedItem = null;
            Refresh();
        }

        private void Refresh()
        {
            RefreshDataSource();
        }
    }
}
