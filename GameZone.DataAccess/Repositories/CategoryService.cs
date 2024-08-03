


namespace GameZone.DataAccess.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository

{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
   
}
