using Domain.DTO;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace NewsAggregatorApi.Controllers
{
    public class NewsController : Controller
    {
        private readonly AppDbContext dbContext;
        public NewsController(AppDbContext dbcontext)
        {
            dbContext = dbcontext;
        }
        public async Task Create(NewsDTO newNews)
        {
            if (newNews != null)
            {
                var createNews = new News
                {
                    Title = newNews.Title,
                    Url = newNews.Url,
                    PublishDate = newNews.PublishDate,
                    Description = newNews.Description,
                    NewsSiteId = newNews.NewsSiteId
                };
                await dbContext.News.AddAsync(createNews);
            }
            dbContext.SaveChanges();
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
