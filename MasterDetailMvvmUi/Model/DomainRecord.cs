namespace MasterDetailMvvmUi.Model
{
    public class DomainRecord : IDomainRecord
    {
        public string Name { get; set; }

        public ParentRecord Parent { get; set; }

        public int ParentId => Parent?.Id ?? 0;

        public StateEnum State { get; set; }
    }
}
