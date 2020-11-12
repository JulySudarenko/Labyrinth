using System.Collections;


namespace CSharpUnityExamples
{
    public static class UserfulExtentions
    {
        public static int CountSymbols(this string self)
        {
            int count = self.Length;
            return count;
        }
        
        public static bool IsOneOf<T>(this T self, params T[] elem)
        {
            return ((IList) elem).Contains(self);
        }
    }
}