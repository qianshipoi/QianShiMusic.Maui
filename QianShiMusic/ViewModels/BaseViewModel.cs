using CommunityToolkit.Mvvm.ComponentModel;

namespace QianShiMusic.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        string? _title;
    }

    public interface IBasePageViewModel
    {
        void OnNavigatedTo();
        void OnNavigatedFrom();
        void OnApplyParameters(IParameters parameters);
        void OnApplyFirstParameters(IParameters parameters);
        void OnApplyOtherParameters(IParameters parameters);
    }

    public partial class BasePageViewModel : ObservableObject, IBasePageViewModel
    {
        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        string? _title;
        public virtual void OnApplyParameters(IParameters parameters)
        {
        }

        public virtual void OnApplyFirstParameters(IParameters parameters)
        {
        }

        public virtual void OnApplyOtherParameters(IParameters parameters)
        {
        }

        public virtual void OnNavigatedTo()
        {
        }

        public virtual void OnNavigatedFrom()
        {
        }
    }

    public interface IParameters
    {

    }
}
