using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using VinylRecodShop.Model.Partial;
using VinylRecordShop.Services.Services;

namespace VinylRecordShop.ViewModels.Base
{
    public abstract partial class EntityViewModel<T> : ViewModelBase, IDataErrorInfo where T : IEntity
    {
        private readonly int _entityId;
        private readonly IEntityService<T> _entityService;
        private T _entity;

        public T Entity
        {
            get { return _entity; }
        }

        protected EntityViewModel()
        {
        }

        protected EntityViewModel(T entity)
        {
            _entity = entity;
            _entityId = entity.Id;
        }

        protected EntityViewModel(int entityId, IEntityService<T> service)
        {
            _entityId = entityId;
            _entityService = service;
            _entity = _entityService.Get(_entityId);
        }

        protected virtual void InitializeObject()
        {
            _entity = _entityService.Get(_entityId);
        }

        protected abstract Page GetListPage();

        #region Validating

        public bool IsValidating;
        public Dictionary<string, string> Errors = new Dictionary<string, string>();

        public bool IsValid()
        {
            IsValidating = true;
            try
            {
                CheckProperties();
            }
            finally
            {
                IsValidating = false;
            }
            return !Errors.Any();
        }

        protected abstract void CheckProperties();

        protected abstract string Validate(string fieldName);

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (!IsValidating) return result;
                Errors.Remove(columnName);

                result = Validate(columnName);

                if (!string.IsNullOrWhiteSpace(result)) Errors.Add(columnName, result);

                return result;
            }
        }

        public string Error { get; }

        #endregion
    }
}