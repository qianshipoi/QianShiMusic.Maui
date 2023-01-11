using QianShiMusicClient.Maui.Models;
using QianShiMusicClient.Maui.Views;

namespace QianShiMusicClient.Maui.Helpers
{
    public class MainTabDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FoundDataTemplate { get; set; } = null!;
        public DataTemplate HomeDataTemplate { get; set; } = null!;

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if(item is TabBarItem tab)
            {
                if(tab.ViewType == typeof(FoundView))
                {
                    return FoundDataTemplate;
                }
            }

            return HomeDataTemplate;
        }
    }
}
