



using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameZone.DataAccess.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
{
    private readonly ApplicationDbContext _context;
    private DbSet<T> _dbSet;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
        
    }


    

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? criteria = null, string[]? includes = null)
    {
        IQueryable<T> query = _dbSet;
        if (criteria != null)
            query = query.Where(criteria);


        if (includes != null)
        {
            query = ApplyIncludes(query, includes);
        }
        return await query.AsNoTracking().ToListAsync();
    }


    



    public async Task<T?> GetByAsync(Expression<Func<T, bool>> criteria, string[]? includes = null)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach (var item in includes)
            {
                query = ApplyIncludes(query, includes);
            }
        }
        return await query.SingleOrDefaultAsync(criteria);
    }

    private static IQueryable<T> ApplyIncludes(IQueryable<T> query, string[] includes)
    {
        foreach (var include in includes)
        {
            var properties = include.Split('.');
            query = query.Include(properties[0]);

            for (int i = 1; i < properties.Length; i++)
            {
                var path = string.Join(".", properties.Take(i + 1));
                query = query.Include(path);
            }
        }

        return query;
    }


    public async Task<T?> FindByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IEnumerable<SelectListItem> GetListItems()
    {
        return _dbSet
            .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
            .OrderBy(x => x.Text)
            .AsNoTracking()
            .ToList();
    }

    public async Task AddAsync(T entity)
    {
        await _context.AddAsync(entity);
    }


    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Remove(T entity)
    {
        _context.Remove(entity);
    }
}
