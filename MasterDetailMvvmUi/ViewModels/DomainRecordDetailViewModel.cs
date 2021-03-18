namespace MasterDetailMvvmUi.ViewModels
{
    using System.Linq;
    using Caliburn.Micro;
    using JetBrains.Annotations;
    using Model;

    internal class DomainRecordDetailViewModel : PropertyChangedBase, IDomainRecord
    {
        private DomainRecordDetailListViewModel _item;

        public DomainRecordDetailViewModel()
        {
            States = new EnumListViewModel<StateEnum>();
        }

        public EnumListViewModel<StateEnum> States { get; }

        public NameWrapper<StateEnum> SelectedState
        {
            get
            {
                return States.FirstOrDefault(s => s.Wrapped == State);
            }
            set
            {
                if (State != value.Wrapped)
                {
                    State = value.Wrapped;
                    NotifyOfPropertyChange();
                }
            }
        }

        public StateEnum State
        {
            get => _item?.State ?? StateEnum.Default;
            set
            {
                if (_item != null && value != _item.State)
                {
                    _item.State = value;
                    NotifyOfPropertyChange();
                    NotifyOfPropertyChange(nameof(SelectedState));
                }
            }
        }

        [UsedImplicitly]
        public string ParentName => _item?.ParentName;

        public int ParentId => _item?.ParentId ?? 0;

        public string Name
        {
            get => _item?.Name;
            set => _item.Name = value;
        }


        public BindableCollection<NameWrapper<ParentRecord>> Parents { get; } =
            new BindableCollection<NameWrapper<ParentRecord>>();


        public NameWrapper<ParentRecord> SelectedParent
        {
            get
            {
                return Parents.FirstOrDefault(s => s.Wrapped == Parent);
            }
            set
            {
                if (Parent != value.Wrapped)
                {
                    Parent = value.Wrapped;
                    NotifyOfPropertyChange();
                }
            }
        }

        public ParentRecord Parent
        {
            get => ((IDomainRecord)_item)?.Parent;
            set
            {
                if (_item != null && ((IDomainRecord)_item).Parent != value)
                {
                    ((IDomainRecord)_item).Parent = value;
                    NotifyOfPropertyChange();
                    NotifyOfPropertyChange(nameof(SelectedParent));
                }
            }
        }

        public DomainRecordDetailListViewModel Item
        {
            get => _item;
            set
            {
                if (!Equals(value, _item))
                {
                    _item = value;
                    NotifyOfPropertyChange(string.Empty);
                }
            }
        }

    }
}