using InmSale.Models;
using InmSale.Repositories.Commons;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace InmSale.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private IMongoCollection<Project> _projectsCollection;

        public ProjectsRepository(IGenericDbRepository repository) => _projectsCollection = repository.GetCollection<Project>(ReadPreference.Primary);

        public async Task<long> CountAsync(Expression<Func<Project, bool>>? matchExpression)
        {
            var filterBuilder = Builders<Project>.Filter;
            FilterDefinition<Project> filter; 
            if (matchExpression is not null)
                filter = filterBuilder.Where(matchExpression);
            else
                filter = filterBuilder.Empty; 
            return await _projectsCollection.CountDocumentsAsync(filter);
        }

        public async Task RegisterAsync(Project project) => await _projectsCollection.InsertOneAsync(project);
    }
}
