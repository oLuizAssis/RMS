using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Data.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<List<T>> Get(Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>> orderBy = null, bool descending = false);
        Task<T> GetFirst(Expression<Func<T, bool>> predicate);

        //List<T> GetNormal(Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>> orderBy = null, bool descending = false);

        Task<AsyncTableQuery<T>> AsQueryable();

        Task<int> Insert(T entity);
        Task<int> InsertList(List<T> entity);

        Task<int> Update(T entity);
        Task<int> UpdateList(List<T> entity);

        Task<int> Delete(T entity);
        Task DeleteList(List<T> entity);
        Task DeleteAll();
        Task<List<T>> QueryAsync(string query, params object[] parametros);
        Task<List<int>> QueryAsyncCount(string query, params object[] parametros);
        Task<double> FindWithQueryAsync(string query, params object[] parametros);
        Task<int> FindWithQueryCountAsync(string query, params object[] parametros);
    }
}
