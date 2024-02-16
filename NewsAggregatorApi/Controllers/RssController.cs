using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsAggregatorApi.Services.Interface;
using System.ServiceModel.Syndication;
using System.Xml;

namespace NewsAggregatorApi.Controllers
{

    public class RssController : BaseController
    {
        private IRssService RssService;
        public RssController(IRssService rssService)
        {
            RssService = rssService;
        }

        [Produces("application/json")]
        [HttpPost("Create")]
        public async Task SaveRssFeed()
        {
            await RssService.RssFeed();
        }
    }
}
