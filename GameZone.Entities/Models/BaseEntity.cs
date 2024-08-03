
using GameZone.Entities.Interfaces;

namespace GameZone.Entities.Models;

public class BaseEntity :IEntity
{
    public int Id { get; set; }

    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
}
