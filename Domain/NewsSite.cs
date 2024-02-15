using Domain.PersistentObj;

namespace Domain
{
    public class NewsSite : PersistentObject
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public List<News> News { get; set; }
        public long NewsId { get; set; }
        public string RssUrl { get; set; }
    }
}
