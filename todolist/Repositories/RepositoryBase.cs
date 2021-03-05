using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using todolist.Database;
using todolist.Exceptions;
using todolist.Models;

namespace todolist.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: ModelBase
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public async Task<string> Insert(T model, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                model.Id = Guid.NewGuid().ToString();
            }
            await _dbSet.AddAsync(model, cancellationToken);
            var result = await _db.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return model.Id;
            }
            throw new BusinessException("Failed to add new item");

        }

        public async Task<int> Delete(string id, CancellationToken cancellationToken)
        {
            var item = await _dbSet.SingleOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
            if (item != null)
            {
                item.IsDeleted = true;
                _dbSet.Update(item);
            }

            return await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> Update(T model, CancellationToken cancellationToken)
        {
            var item = await _dbSet.Where(x => x.Id == model.Id).SingleOrDefaultAsync(cancellationToken: cancellationToken);
            _db.Entry(item).CurrentValues.SetValues(model);
            return await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> filterDefinition)
        {
            return await _dbSet.Where(filterDefinition).Where(x => x.IsDeleted != true).ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}