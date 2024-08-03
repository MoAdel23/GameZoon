

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace GameZone.Entities.Interfaces;

public interface IBaseRepository<T> where T : class
{
   

    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>>? criteria = null,string[]? includes = null);

    Task<T?> GetByAsync(Expression<Func<T, bool>> criteria , string[]? includes = null);

    Task<T?> FindByIdAsync(int id);

    IEnumerable<SelectListItem> GetListItems();



    Task AddAsync(T entity);

    void Update(T entity);

    void Remove(T entity);
}
