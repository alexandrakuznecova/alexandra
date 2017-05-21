using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Newtonsoft.Json;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecodShop.Model.Partial;

namespace VinylRecordShop.Services.Services.Implementation
{
    public class ServiceBase<T> : IEntityService<T> where T : class , IEntity
    {
        protected VinylRecordEntities EntityContext;
        public ServiceBase()
        {
            EntityContext = new VinylRecordEntities();
        }
        public T Get(int id)
        {
            if (id == 0)
            {
                return Create();
            }
            return EntityContext.Set<T>().FirstOrDefault(entity => entity.Id.Equals(id));
        }

        public bool Delete(T entity)
        {
            EntityContext.Entry(entity).State = EntityState.Deleted;
            EntityContext.SaveChanges();
            Log(ActionType.Delete, entity);
            return true;
        }

        public T Create()
        {
            return EntityContext.Set<T>().Create();
        }

        public void AddOrUpdate(T entity)
        {
            bool isCreate = entity.Id == 0;
            if (isCreate)
            {
                EntityContext.Set<T>().Add(entity);
            }

            DbEntityEntry<T> entityEntry = EntityContext.Entry(entity);
            entityEntry.State = isCreate ? EntityState.Added : EntityState.Modified;

            EntityContext.SaveChanges();

            Log(isCreate ? ActionType.Add : ActionType.Update , entity);
        }

        public virtual List<T> GetAll()
        {
            var query = EntityContext.Set<T>();
            return query.ToList();
        }

        public IQueryable<T> GetQuery()
        {
            return EntityContext.Set<T>();
        }

        public virtual bool CanDelete(int id)
        {
            return true;
        }

        public bool SaveChanges()
        {
            EntityContext.SaveChanges();
            return true;
        }

        protected void Log(ActionType actionType, T entity = null)
        {
            EntityEventLog logRecord = EntityContext.EntityEventLogs.Create();
            logRecord.ActionDate = DateTime.Now;
            logRecord.ActionType = (short) actionType;
            logRecord.EntityType = typeof(T).Name;

            if (entity != null && entity.Id != 0)
            {
                logRecord.EntityJson = JsonConvert.SerializeObject(entity, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                logRecord.EntityId = entity.Id;
            }
            EntityContext.EntityEventLogs.Add(logRecord);

            EntityContext.SaveChanges();
        }
    }

    public enum ActionType
    {
        [Display(Name = "Добавление")]
        Add = 0,
        [Display(Name = "Обновление")]
        Update = 1,
        [Display(Name = "Удаление")]
        Delete = 2
    }
}
