namespace NewsAggregatorApi.DTO
{
    public class NewsDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public long NewsSiteId { get; set; }
    }
}
