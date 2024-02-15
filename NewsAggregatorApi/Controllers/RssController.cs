using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ServiceModel.Syndication;
using System.Xml;

namespace NewsAggregatorApi.Controllers
{
    public class RssController : Controller
    {
        private AppDbContext dbContext;
        public RssController(AppDbContext context)
        {
            dbContext = context;
        }

        [Produces("application/json")]
        [HttpPost("Create")]
        public async Task SaveRssFeed(string rssUrl)
        {
            SyndicationFeed feed = null;

            using (var client = new HttpClient())
            {
                using (var reader = XmlReader.Create("https://visualstudiomagazine.com/rss-feeds/news.aspx"))
                {
                    feed = SyndicationFeed.Load(reader);
                }
            }
            if (feed != null)
            {
                foreach (var element in feed.Items)
                {
                    var newNews = new News
                    {
                        Title = element.Title.Text,
                        Url = element.BaseUri.AbsoluteUri,
                        Description = element.Content.ToString(),
                        PublishDate = element.PublishDate,
                        NewsSiteId = dbContext.NewsSites.Where(x => x.RssUrl == rssUrl).FirstOrDefault().Id
                    };
                    await dbContext.News.AddAsync(newNews);

                }
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
