using QianShiMusic.ViewModels;

namespace QianShiMusic.Views;

public partial class PlaylistDetailPage
{
    public PlaylistDetailPage(PlaylistDetailViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}