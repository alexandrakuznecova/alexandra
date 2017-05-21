using System.Linq;
using VinylRecodShop.Model.Database.DatabaseContext;

namespace VinylRecordShop.Services.Services.Implementation
{
    public class PublisherService : ServiceBase<Publisher>
    {
        public override bool CanDelete(int id)
        {
            bool canDelete = !EntityContext.VinylRecords.Any(vr => vr.PublisherId == id);
            return base.CanDelete(id) && canDelete;
        }
    }
}
