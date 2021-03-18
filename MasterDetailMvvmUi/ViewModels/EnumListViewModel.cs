namespace MasterDetailMvvmUi.ViewModels
{
    using System;
    using System.Linq;
    using Caliburn.Micro;

    public class EnumListViewModel<T> : BindableCollection<NameWrapper<T>>
    {
        public EnumListViewModel()
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(@"Must be enum.", nameof(enumType));
            }

            foreach (var nvPair in Enum.GetValues(enumType).Cast<T>().Select(v => new NameWrapper<T>(Enum.GetName(enumType, v), v)))
            {
                Add(nvPair);
            }
        }
    }
}