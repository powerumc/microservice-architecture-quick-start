using System;

namespace Powerumc.RssFeeds
{
    public static class Guard
    {
        public static void ThrowIfNullOrWhitespace(string str, string name)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException(name);
        }

        public static void ThrowIfNull(object obj, string name)
        {
            if (obj == null)
                throw new ArgumentNullException(name);
        }

        public static void ThrowIfZeroOrLess(long num, string name)
        {
            if (num <= 0)
                throw new ArgumentException(name);
        }

        public static void ThrowIf<T>(this T obj, Predicate<T> predicate, string name)
        {
            if (predicate(obj))
                throw new ArgumentException(name);
        }
    }
}