


namespace GameZone.DataAccess.Repositories;

public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
{
    private readonly ApplicationDbContext _context;

    public DeviceRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

  
}
