using QianShiMusic.Resources.Strings;

namespace QianShiMusic
{
    [ContentProperty(nameof(Key))]
    public class LocalizeExtension : IMarkupExtension<BindingBase>
    {
        public string Key { get; set; }
        public IValueConverter Converter { get; set; }

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            return new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Key}]",
                Source = LocalizationResourceManager.Instance,
                Converter = Converter
            };
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}
