using Domain;
using Microsoft.EntityFrameworkCore;
using NewsAggregatorApi.Services.Interface;
using System.ServiceModel.Syndication;
using System.Xml;

namespace NewsAggregatorApi.Services
{
    public class RssService : IRssService
    {
        private readonly AppDbContext dbContext;
        public RssService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task RssFeed( )
        {
            SyndicationFeed feed = null;
            //foreach (var site in dbContext.NewsSites)
            //{

            foreach (var site in dbContext.NewsSites)
            {
                using (var client = new HttpClient())
                {
                    using (var reader = XmlReader.Create(site.Url))
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
                            Url = element.Id.ToString(),
                            Description = element.Summary.Text.ToString(),
                            PublishDate = element.PublishDate.UtcDateTime,
                            NewsSiteId = dbContext.NewsSites.Where(x => x.RssUrl == site.RssUrl).FirstOrDefault().Id
                        };
                        await dbContext.News.AddAsync(newNews);

                    }
                    await dbContext.SaveChangesAsync();
                }
            }
        }

    //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        SyndicationFeed feed = null;
    //        foreach (var site in dbContext.NewsSites)
    //        {


    //            using (var client = new HttpClient())
    //            {
    //                using (var reader = XmlReader.Create(site.RssUrl))
    //                {
    //                    feed = SyndicationFeed.Load(reader);
    //                }
    //            }
    //            if (feed != null)
    //            {
    //                foreach (var element in feed.Items)
    //                {
    //                    var newNews = new News
    //                    {
    //                        Title = element.Title.Text,
    //                        Url = element.BaseUri.AbsoluteUri,
    //                        Description = element.Content.ToString(),
    //                        PublishDate = element.PublishDate.Date,
    //                        NewsSiteId = dbContext.NewsSites.Where(x => x.RssUrl == site.RssUrl).FirstOrDefault().Id
    //                    };
    //                    await dbContext.News.AddAsync(newNews);

    //                }
    //                await dbContext.SaveChangesAsync();
    //            }
    //        }
    //        await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
    //    }
    }
}
