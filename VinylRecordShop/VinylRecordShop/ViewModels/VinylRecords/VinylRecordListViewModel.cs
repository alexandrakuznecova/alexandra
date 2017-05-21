using System.Windows.Controls;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.Pages.VinylRecord;
using VinylRecordShop.Services.Services.Implementation;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop.ViewModels.VinylRecords
{
    public class VinylRecordListViewModel : ListViewModelBase<VinylRecord>
    {
        public VinylRecordListViewModel() : base(new VinylRecordService())
        {
            DataGridFilterViewModel = new VinylRecordFilterViewModel();
        }

        protected override EntityViewModel<VinylRecord> Map(VinylRecord entity)
        {
            return new VinylRecordViewModel(entity);
        }
        protected override Page GetDetailPage(int entityId = 0)
        {
            return new VinylRecordDetailPage(new VinylRecordViewModel(entityId));
        }
    }
}
