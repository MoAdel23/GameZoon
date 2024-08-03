

namespace GameZone.Entities.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Category { get; }
    IDeviceRepository Device { get; }
    IGameRepository Game { get; }

    int Compelete();
}
