using Microsoft.AspNetCore.Mvc;
using NewsAggregatorApi.DTO;
using NewsAggregatorApi.Services.Interface;

namespace NewsAggregatorApi.Controllers
{
    public class NewsSiteController : BaseController
    {
        private INewsSiteService NewsSiteService;
        public NewsSiteController(INewsSiteService newsSiteService)
        {
            NewsSiteService = newsSiteService;
        }

        [Produces("application/json")]
        [HttpPost("Create")]
        public async Task Create(NewsSiteDTO site)
        {
            await NewsSiteService.Create(site);

        }

        [Produces("application/json")]
        [HttpDelete("Delete")]
        public async Task Delete(long id)
        {
           await NewsSiteService.Delete(id);
        }

        [Produces("application/json")]
        [HttpPut("Update")]
        public async Task Update(NewsSiteDTO site)
        {
            await NewsSiteService.Update(site);
        }
    }
}
