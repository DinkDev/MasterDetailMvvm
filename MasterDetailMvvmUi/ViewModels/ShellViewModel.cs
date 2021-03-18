namespace MasterDetailMvvmUi.ViewModels
{
    using System.Collections.Generic;
    using System.Reflection;
    using Caliburn.Micro;
    using Model;

    internal sealed class ShellViewModel : Screen, IShell
    {
        private DomainRecordMasterViewModel _master;
        private DomainRecordDetailViewModel _detail;

        public ShellViewModel()
        {
            DisplayName = Assembly.GetExecutingAssembly().GetName().Name;

            var items = new List<DomainRecord>();

            var father = new ParentRecord { Id = 999, Name = "Big Daddy" };
            var mother = new ParentRecord { Id = 1001, Name = "Little Momma" };
            items.Add(new DomainRecord { Name = "First", Parent = father, State = StateEnum.Default });
            items.Add(new DomainRecord { Name = "Second", Parent = mother, State = StateEnum.Default });

            _detail = new DomainRecordDetailViewModel();

            _master = new DomainRecordMasterViewModel(items, _detail);
        }

        public DomainRecordMasterViewModel Master
        {
            get => _master;
            set
            {
                if (!Equals(value, _master))
                {
                    _master = value;
                    NotifyOfPropertyChange();
                }
            }
        }

    }
}
