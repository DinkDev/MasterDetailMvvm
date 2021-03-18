namespace MasterDetailMvvmUi.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Caliburn.Micro;

    internal class DetailViewModel<T> : PropertyChangedBase
    {
        [Browsable(false)]
        [Display(AutoGenerateField = false)]
        protected T Wrapped { get; set; }
    }
}