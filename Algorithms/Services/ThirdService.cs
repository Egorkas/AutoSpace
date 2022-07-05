namespace Algorithms.Services
{
    public static class ThirdService<T>
    {
        public static List<T> RemoveOddElements(List<T> list)
        {
            return list.Where(v => list.IndexOf(v) % 2 == 1).ToList();
        }
    }
}
