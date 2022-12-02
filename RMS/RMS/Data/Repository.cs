using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RMS.Data.Interfaces;
using RMS.Models;
using SQLite;

namespace RMS.Data
{
    public class Repository<T> : BaseDatabase, IRepository<T> where T : class, new()
    {

        private SQLiteAsyncConnection db;

        public Repository()
        {
            this.db = Task.Run(async () => await GetDatabaseConnection<T>()).Result;

        }

        public async Task<AsyncTableQuery<T>> AsQueryable()
        {
            return db.Table<T>();
        }

        public async Task<List<T>> Get()
        {
            return await AttemptAndRetry(() => db.Table<T>().ToListAsync()).ConfigureAwait(false);
        }

        public async Task<List<T>> Get(Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>> orderBy = null, bool descending = false)
        {
            var query = db.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
            {
                if (descending)
                    query = query.OrderByDescending(orderBy);
                else
                    query = query.OrderBy(orderBy);
            }


            return await AttemptAndRetry(() => query.ToListAsync()).ConfigureAwait(false);
        }

        public async Task<T> Get(int id)
        {
            return await AttemptAndRetry(() => db.FindAsync<T>(id)).ConfigureAwait(false);
        }

        public async Task<T> GetFirst(Expression<Func<T, bool>> predicate)
        {
            return await AttemptAndRetry(() => db.FindAsync<T>(predicate)).ConfigureAwait(false);
        }

        public async Task<int> Insert(T entity)
        {
            return await AttemptAndRetry(() => db.InsertAsync(entity)).ConfigureAwait(false);
        }

        public async Task<int> InsertList(List<T> entity)
        {
            return await AttemptAndRetry(() => db.InsertAllAsync(entity)).ConfigureAwait(false);
        }

        public async Task<int> Update(T entity)
        {
            return await AttemptAndRetry(() => db.UpdateAsync(entity)).ConfigureAwait(false);
        }

        public async Task<int> UpdateList(List<T> entity)
        {
            return await AttemptAndRetry(() => db.UpdateAllAsync(entity)).ConfigureAwait(false);
        }

        public async Task<int> Delete(T entity)
        {
            return await AttemptAndRetry(() => db.DeleteAsync(entity)).ConfigureAwait(false);
        }

        public async Task DeleteList(List<T> entity)
        {
            foreach (var item in entity)
            {
                await AttemptAndRetry(() => db.DeleteAsync(item)).ConfigureAwait(false);
            }
        }

        public async Task DeleteAll()
        {
            await AttemptAndRetry(() => db.DeleteAllAsync<T>()).ConfigureAwait(false);
        }
        public async Task<List<T>> QueryAsync(string query, params object[] parametros)
        {
            return await AttemptAndRetry(() => db.QueryAsync<T>(query, parametros)).ConfigureAwait(false);
        }

        public async Task<List<int>> QueryAsyncCount(string query, params object[] parametros)
        {
            return await AttemptAndRetry(() => db.QueryAsync<int>(query, parametros)).ConfigureAwait(false);
        }

        public async Task<double> FindWithQueryAsync(string query, params object[] parametros)
        {
            return await AttemptAndRetry(() => db.FindWithQueryAsync<double>(query, parametros)).ConfigureAwait(false);
        }

        public async Task<int> FindWithQueryCountAsync(string query, params object[] parametros)
        {
            return await AttemptAndRetry(() => db.FindWithQueryAsync<int>(query, parametros)).ConfigureAwait(false);
        }
    }
}

