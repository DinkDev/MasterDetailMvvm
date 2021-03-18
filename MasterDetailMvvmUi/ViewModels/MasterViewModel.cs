namespace MasterDetailMvvmUi.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Caliburn.Micro;
    using JetBrains.Annotations;

    internal class MasterViewModel<T, TVm> : PropertyChangedBase
    {
        private BindableCollection<TVm> _items = new BindableCollection<TVm>();
        private TVm _selectedItem;

        public MasterViewModel(IEnumerable<T> items, Func<T,TVm> convert, Action<TVm> selectionChangedCallback)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (convert == null)
            {
                throw new ArgumentNullException(nameof(convert));
            }

            SelectionChangedCallback = selectionChangedCallback ?? throw new ArgumentNullException(nameof(selectionChangedCallback));

            Items.AddRange(items.Select(convert));
        }

        [UsedImplicitly]
        public TVm SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (!EqualityComparer<TVm>.Default.Equals(value, _selectedItem))
                {
                    _selectedItem = value;
                    NotifyOfPropertyChange();

                    SelectionChangedCallback(_selectedItem);
                }
            }
        }

        public BindableCollection<TVm> Items
        {
            get => _items;
            set
            {
                if (!Equals(_items, value))
                {
                    _items = value;
                    NotifyOfPropertyChange(string.Empty);
                }
            }
        }

        public Action<TVm> SelectionChangedCallback { get; }
    }
}
