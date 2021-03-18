namespace MasterDetailMvvmUi.ViewModels
{
    using System.Collections.Generic;
    using Model;

    internal class DomainRecordMasterViewModel : MasterViewModel<DomainRecord, DomainRecordDetailListViewModel>
    {
        public DomainRecordMasterViewModel(
            IEnumerable<DomainRecord> items,
            DomainRecordDetailViewModel itemDetail)
            : base(items, t => new DomainRecordDetailListViewModel(t), i => itemDetail.Item = i)
        {
            ItemDetail = itemDetail;
        }

        public DomainRecordDetailViewModel ItemDetail { get; }
    }
}