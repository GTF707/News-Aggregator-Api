using NewsAggregatorApi.DTO;
using NewsAggregatorApi.Services.Interface;

namespace NewsAggregatorApi.Services
{
    public class NewsSiteService : INewsSiteService
    {
        private readonly AppDbContext dbContext;
        public NewsSiteService(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
        }

        public async Task Create(NewsSiteDTO site)
        {
            await dbContext.AddAsync(site);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var delete = dbContext.NewsSites.Where(x => x.Id == id);
            dbContext.Remove(delete);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(NewsSiteDTO site)
        {
            var update = dbContext.NewsSites.Where(x => x.Id == site.Id).FirstOrDefault();
            update.Url = site.Url;
            update.Name = site.Name;
            if (update != null)
            {
                dbContext.NewsSites.Update(update);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
