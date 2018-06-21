namespace Powerumc.RssFeeds.ValueObjects
{
    public class Author : ValueObject
    {
        public string Title { get; }
        public string Url { get; }

        public Author(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}