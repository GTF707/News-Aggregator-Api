using Domain;
using NewsAggregatorApi.DTO;

namespace NewsAggregatorApi.Services.Interface
{
    public interface INewsService
    {
        public Task Create(NewsDTO newsDTO);
        public Task Delete(long id);
        public Task<List<News>> Search(string search);
        public Task Update(NewsDTO updateNews);

    }
}
