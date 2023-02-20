using CommunityToolkit.Mvvm.ComponentModel;

namespace QianShiMusic.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        string _title;
    }
}
