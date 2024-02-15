using Microsoft.AspNetCore.Mvc;

namespace NewsAggregatorApi.Controllers
{
    public class NewsSiteController : Controller
    {
        private readonly AppDbContext dbContext;
        public NewsSiteController(AppDbContext dbcontext)
        {
            dbContext = dbcontext;
        }

        [Produces("application/json")]
        [HttpPost("Create")]
        public async Task Create(NewsSiteDTO site)
        {
            await dbContext.AddAsync(site);
            await dbContext.SaveChangesAsync();

        }

        [Produces("application/json")]
        [HttpPost("Delete")]
        public async Task Delete(long id)
        {
            var delete = dbContext.NewsSites.Where(x => x.Id == id);
            dbContext.Remove(delete);
            await dbContext.SaveChangesAsync();
        }

        [Produces("application/json")]
        [HttpPost("Update")]
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
