using System.Collections.Generic;

namespace VinylRecordShop.Services.Services
{
    public interface IEntityService<T>
    {
        T Get(int id);
        bool Delete(T entity);
        T Create();
        void AddOrUpdate(T entity);
        List<T> GetAll();
        bool CanDelete(int id);
        bool SaveChanges();
    } 
}
