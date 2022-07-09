namespace Algorithms.Services
{
    public class SecondService
    {
        public string RemoveRepeatedChars(string text)
        {
            if(string.IsNullOrEmpty(text))
                return string.Empty;

            return new string(text.ToCharArray().Distinct().ToArray());
        }
    }
}
