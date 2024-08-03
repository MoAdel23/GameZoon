

namespace GameZone.Entities.Models;

public class GameDevivce
{
    public int GameId { get; init; }
    public virtual Game Game { get; init; } = default!;

    public int DeviceId { get; init; }
    public virtual Device Device { get; init; } = default!;
}
