using CommunityToolkit.Mvvm.ComponentModel;

namespace QianShiMusicClient.Maui.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    string _title;

    [ObservableProperty]
    bool _isBusy;
}


