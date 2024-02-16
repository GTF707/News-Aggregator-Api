using NewsAggregatorApi.DTO;

namespace NewsAggregatorApi.Services.Interface
{
    public interface INewsSiteService
    {
        public Task Create(NewsSiteDTO site);
        public Task Delete(long id);
        public Task Update(NewsSiteDTO site);

    }
}
