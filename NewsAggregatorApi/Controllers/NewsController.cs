using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsAggregatorApi.DTO;
using NewsAggregatorApi.Services.Interface;
using System;

namespace NewsAggregatorApi.Controllers
{
    public class NewsController : BaseController 
    {
        private INewsService NewsService;
        public NewsController( INewsService newsService)
        {
            NewsService = newsService;
        }

        [Produces("application/json")]
        [HttpPost("Create")]
        public async Task Create(NewsDTO newNews)
        {
            await NewsService.Create(newNews);
        }

        [Produces("application/json")]
        [HttpPost("Delete")]
        public async Task Delete(long id)
        {
            await NewsService.Delete(id);
        }

        [Produces("application/json")]
        [HttpPost("Search")]
        public async Task<List<News>> Search(string search)
        {
            return await NewsService.Search(search);
        }

        [Produces("application/json")]
        [HttpPost("Update")]
        public async Task Update(NewsDTO updateNews)
        {
            await NewsService.Update(updateNews);
        }
    }
}
