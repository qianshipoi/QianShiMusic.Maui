using QianShiMusic.ViewModels;

namespace QianShiMusic.Views.Pages
{
    public class BaseContentPage : ContentPage, IQueryAttributable
    {
        private IParameters? parameters;

        public BaseContentPage()
        {
            Shell.Current.Navigating += Current_Navigating;
        }

        private void Current_Navigating(object? sender, ShellNavigatingEventArgs e)
        {
            if (Shell.Current.CurrentPage == this)
            {
                var targetString = e.Target.Location.ToString();

                if (targetString.StartsWith("//") && !targetString.Contains(e.Current.Location.ToString()))
                {
                    parameters = null;
                }
            }
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            if (BindingContext is IBasePageViewModel viewModel)
            {
                viewModel.OnNavigatedTo();
            }
        }

        protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
        {
            base.OnNavigatedFrom(args);
            if (BindingContext is IBasePageViewModel viewModel)
            {
                viewModel.OnNavigatedFrom();
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var first = parameters is null;
            parameters = query.FirstOrDefault().Value as IParameters;
            if (BindingContext is IBasePageViewModel viewModel)
            {
                viewModel.OnApplyParameters(parameters);

                if (first)
                {
                    viewModel.OnApplyFirstParameters(parameters);
                }
                else
                {
                    viewModel.OnApplyOtherParameters(parameters);
                }
            }
        }
    }
}
