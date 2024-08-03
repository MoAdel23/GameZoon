



namespace GameZone.Entities.Models;

public class Game : BaseEntity
{
    [MaxLength(2500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Cover { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = default!;

    public ICollection<GameDevivce> Devices { get; set; } = new List<GameDevivce>();    




}
