namespace MasterDetailMvvmUi.Model
{
    public interface IDomainRecord
    {
        string Name { get; set; }
        ParentRecord Parent { get; set; }
        int ParentId { get; }
        StateEnum State { get; set; }
    }
}