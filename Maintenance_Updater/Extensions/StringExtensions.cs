namespace Maintenance_Updater.Extensions
{
    public static class StringExtensions
    {
        public static string Replace(this string self, char value, int index)
        {
            return self.Replace(value.ToString(), index);
        }

        public static string Replace(this string self, string value, int index)
        {
            string newStr = self.Substring(0, index) + value;

            if (index + value.Length == self.Length)
                return newStr;

            int startIndex = index + value.Length;
            int endLength = self.Length - index - value.Length;

            return newStr + self.Substring(startIndex, endLength);
        }
    }
}
