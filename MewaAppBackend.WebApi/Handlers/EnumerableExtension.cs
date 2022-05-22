namespace MewaAppBackend.WebApi.Handlers
{
    public class EnumerableExtension<T,U>
    {
        public static EnumerableDifference<T> Difference(this IEnumerable<T> first, IEnumerable<U> second, Func<T> descriptor)
        {
            if (first.Count() != second.Count())
                throw new ArgumentException($"Lenghts are not the same! First: {first.Count()}, Second: {second.Count()}");

            for(int i = 0; i < first.Count(); i++)
            {

            }
            var result = new EnumerableDifference<T>();
            return result;
        }
    }

    public class EnumerableDifference<T>
    {
        public IEnumerable<T> Added { get; set; }
        public IEnumerable<T> Modified { get; set; }
        public IEnumerable<T> Removed { get; set; }
    }
}
