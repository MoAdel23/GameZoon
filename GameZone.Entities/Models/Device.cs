



namespace GameZone.Entities.Models;

public class Device :BaseEntity
{
    [MaxLength(50)]
    public string Icon { get; init; } = string.Empty;
   
}
