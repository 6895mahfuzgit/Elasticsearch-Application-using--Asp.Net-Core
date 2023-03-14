using ElasticsearchExampleApp.Models;
using Nest;

namespace ElasticsearchExampleApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IElasticClient _elasticCliente;

        public UserRepository(IElasticClient elasticCliente)
        {
            _elasticCliente = elasticCliente;
        }

        public async Task<User> Get(string id)
        {
            ISearchResponse<User> response = await _elasticCliente.SearchAsync<User>(s => s
            .Index("users")
            .Query(q => q.Term(t => t.Name, id)
            || q.Match(m => m.Field(f => f.Name).Query(id))
            ));
            User result = response?.Documents?.FirstOrDefault();
            return result;

        }

        public async Task<List<User>> GetUsers()
        {
            ISearchResponse<User> response = await _elasticCliente.SearchAsync<User>(s => s
             .Index("users"));

            List<User> users = response?.Documents?.ToList();
            return users;
        }

        public async Task<User> Save(User user)
        {
            IndexResponse savedUser = await _elasticCliente.IndexAsync<User>(user, i => i.Index("users"));

            return user;
        }
    }
}
