using Domain;
using Microsoft.EntityFrameworkCore;
using NewsAggregatorApi.DTO;
using NewsAggregatorApi.Services.Interface;

namespace NewsAggregatorApi.Services
{
    public class NewsService : INewsService
    {
        private readonly AppDbContext dbContext;
        public NewsService(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
        }

        public async Task Create(NewsDTO newsDTO)
        {
            if (newsDTO != null)
            {
                var createNews = new News
                {
                    Title = newsDTO.Title,
                    Url = newsDTO.Url,
                    PublishDate = newsDTO.PublishDate,
                    Description = newsDTO.Description,
                    NewsSiteId = newsDTO.NewsSiteId
                };
                await dbContext.News.AddAsync(createNews);
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var delete = await dbContext.News.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (delete != null)
            {
                dbContext.News.Remove(delete);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<News>> Search(string search)
        {
            return await dbContext.News.Where(article => article.Title.Contains(search)).ToListAsync();
        }

        public async Task Update(NewsDTO updateNews)
        {
            var oldNews = dbContext.News.Where(x => x.Id == updateNews.Id).FirstOrDefault();
            if (oldNews != null)
            {
                oldNews.Title = updateNews.Title;
                oldNews.Url = updateNews.Url;
                oldNews.PublishDate = updateNews.PublishDate;
                oldNews.Description = updateNews.Description;
                oldNews.NewsSiteId = updateNews.NewsSiteId;

                dbContext.Update(oldNews);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
