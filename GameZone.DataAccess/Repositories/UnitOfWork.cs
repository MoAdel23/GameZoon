

namespace GameZone.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public ICategoryRepository Category { get; private set; }

    public IDeviceRepository Device { get; private set; }

    public IGameRepository Game { get; private set; }

    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Category = new CategoryRepository(context);
        Device = new DeviceRepository(context);
        Game = new GameRepository(context);
    }


    public int Compelete()
    {
       return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
