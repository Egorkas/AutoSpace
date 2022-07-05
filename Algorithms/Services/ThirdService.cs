namespace Algorithms.Services
{
    public class ThirdService<T>
    {
        public List<T> RemoveOddElements(List<T> list)
        {
            return list.Where(v => list.IndexOf(v) % 2 == 1).ToList();
        }
    }
}
