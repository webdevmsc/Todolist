using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using todolist.Models;

namespace todolist.Repositories
{
    public interface IRepositoryBase<T> where T: ModelBase
    {
        Task<string> Insert(T model, CancellationToken cancellationToken);
        Task<int> Delete(string id, CancellationToken cancellationToken);
        Task<int> Update(T model, CancellationToken cancellationToken);
        Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> filterDefinition);
        Task<T> GetById(string id);
    }
}