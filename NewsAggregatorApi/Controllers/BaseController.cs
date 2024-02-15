using Microsoft.AspNetCore.Mvc;

namespace NewsAggregatorApi.Controllers
{
    [Route("[controller]")]
    public class BaseController : Controller
    {
        public BaseController()
        {
        }
    }
}
