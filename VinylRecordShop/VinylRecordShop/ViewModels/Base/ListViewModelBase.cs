using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using VinylRecodShop.Model.Partial;
using VinylRecordShop.Services.Services;

namespace VinylRecordShop.ViewModels.Base
{
    public abstract partial class ListViewModelBase<T> : ViewModelBase , IListViewModel where T : class , IEntity 
    {
        private ObservableCollection<EntityViewModel<T>> _dataSource;
        private EntityViewModel<T> _selectedItem;

        private IEntityService<T> _entityService;

        public virtual ObservableCollection<EntityViewModel<T>> EntityDataSource
        {
            get {return _dataSource ?? (_dataSource = InitilizeDataSource()); } 
            set
            {
                _dataSource = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<EntityViewModel<T>> InitilizeDataSource()
        {
            var datasource = new ObservableCollection<EntityViewModel<T>>(LoadDataSource());

            if (DataGridFilterViewModel != null)
            {
                CollectionViewSource.GetDefaultView(datasource).Filter = (entityViewModel) => Filter(entityViewModel as EntityViewModel<T>);
                DataGridFilterViewModel.FilterChanged += OnFilterChanged;
            }

            return datasource;
        }

        public IFilterViewModel<T> DataGridFilterViewModel { get; set; }

        public IEntityService<T> EntityService
        {
            get { return _entityService; }
            set { _entityService = value; }
        }

        public EntityViewModel<T> SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ItemSelected));
                OnPropertyChanged(nameof(DeleteAviable));
            }
        }

        public bool ItemSelected
        {
            get { return SelectedItem != null; }
        }

        public bool DeleteAviable
        {
            get { return ItemSelected && _entityService.CanDelete(SelectedItem.Entity.Id); }
        }

        public ListViewModelBase(IEntityService<T> service)
        {
            _entityService = service;
        }

        protected virtual List<EntityViewModel<T>> LoadDataSource()
        {
            return _entityService.GetAll().Select(Map).ToList();
        }

        protected abstract  EntityViewModel<T> Map(T entity);

        protected abstract  Page GetDetailPage(int entityId = 0);

        public bool RefreshDataSource()
        {
            EntityDataSource = new ObservableCollection<EntityViewModel<T>>(LoadDataSource());
            return true;
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        public void ApplyFilter()
        {
            CollectionViewSource.GetDefaultView(EntityDataSource).Refresh();
        }

        public virtual bool Filter(EntityViewModel<T> entityViewModel)
        {
            if (entityViewModel == null)
            {
                return true;
            }
            return DataGridFilterViewModel.Filter(entityViewModel.Entity);
        }
    }
 }