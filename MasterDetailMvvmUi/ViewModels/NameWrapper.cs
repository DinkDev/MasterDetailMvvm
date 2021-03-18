namespace MasterDetailMvvmUi.ViewModels
{
    public class NameWrapper<T>
    {
        public NameWrapper(string name, T wrapped)
        {
            Name = name;
            Wrapped = wrapped;
        }
        public string Name { get; set; }
        public T Wrapped { get; set; }
    }
}