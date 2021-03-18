namespace MasterDetailMvvmUi.Views
{
    using System;
    using System.Linq;
    using System.Windows.Controls;
    using Caliburn.Micro;
    using JetBrains.Annotations;

    /// <summary>
    /// Interaction logic for DomainRecordMasterView.xaml
    /// </summary>
    [UsedImplicitly]
    public partial class DomainRecordMasterView
    {
        public DomainRecordMasterView()
        {
            InitializeComponent();
        }

        private void Items_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            foreach (var propertyName in typeof(PropertyChangedBase)
                .GetProperties()
                .Select(p => p.Name))
            {
                if (string.Equals(e.PropertyName, propertyName, StringComparison.OrdinalIgnoreCase))
                {
                    e.Cancel = true;
                    break;
                }
            }

        }
    }
}
