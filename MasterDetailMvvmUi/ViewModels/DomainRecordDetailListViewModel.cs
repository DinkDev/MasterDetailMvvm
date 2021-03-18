namespace MasterDetailMvvmUi.ViewModels
{
    using Model;

    internal class DomainRecordDetailListViewModel : DetailViewModel<DomainRecord>, IDomainRecord
    {
        public DomainRecordDetailListViewModel(DomainRecord wrapped)
        {
            Wrapped = wrapped;
        }

        public string Name
        {
            get => Wrapped.Name;
            set
            {
                if (!Equals(Wrapped.Name, value))
                {
                    Wrapped.Name = value;
                    NotifyOfPropertyChange();
                }
            }
        }

        public int ParentId
        {
            get => Wrapped.ParentId;
        }

        ParentRecord IDomainRecord.Parent
        {
            get => Wrapped.Parent;
            set
            {
                if (!Equals(Wrapped.Parent, value))
                {
                    Wrapped.Parent = value;
                    NotifyOfPropertyChange(nameof(ParentName));
                    NotifyOfPropertyChange();
                }
            }
        }

        public string ParentName => Wrapped?.Parent?.Name;

        public StateEnum State
        {
            get => Wrapped.State;
            set
            {
                if (!Equals(Wrapped.State, value))
                {
                    Wrapped.State = value;
                    NotifyOfPropertyChange();
                }
            }
        }
    }
}