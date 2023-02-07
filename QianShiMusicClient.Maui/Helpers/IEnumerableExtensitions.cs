namespace QianShiMusicClient.Maui.Helpers
{
    public static class IEnumerableExtensitions
    {
        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> target)
        {
            foreach (var item in target)
            {
                source.Add(item);
            }
        }
    }
}
