using ElasticsearchExampleApp.Models;

namespace ElasticsearchExampleApp.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> Get(string id);
        Task<User> Save(User user);

    }
}
