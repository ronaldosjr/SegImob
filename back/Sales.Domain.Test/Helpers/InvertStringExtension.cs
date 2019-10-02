using System.Linq;

namespace Sales.Domain.Test.Helpers
{
    public static class InvertStringExtension
    {
        public static string ReverseString(this string source)
        {
            var array = source.ToCharArray().Reverse();
            return new string(array.ToArray());
        }
    }
}
