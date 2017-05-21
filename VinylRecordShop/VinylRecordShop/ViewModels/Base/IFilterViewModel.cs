using System;
using VinylRecodShop.Model.Partial;

namespace VinylRecordShop.ViewModels.Base
{
    public interface IFilterViewModel<T> where T: IEntity
    {
        bool Filter(T enity);
        event EventHandler FilterChanged;
    }
}