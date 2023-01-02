using InmSale.Models;
using System.Linq.Expressions;

namespace InmSale.Repositories;

public interface IProjectsRepository
{
    Task<long> CountAsync(Expression<Func<Project, bool>>? matchExpression);
    Task RegisterAsync(Project project);
}