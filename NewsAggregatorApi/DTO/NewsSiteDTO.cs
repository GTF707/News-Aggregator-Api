using Domain;

namespace NewsAggregatorApi.DTO
{
    public class NewsSiteDTO
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public List<News> News { get; set; }
        public NewsSiteDTO(NewsSite newsSite)
        {
            Url = newsSite.Url;
            Name = newsSite.Name;
        }
    }
}
