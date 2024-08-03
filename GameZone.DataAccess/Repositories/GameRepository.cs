


namespace GameZone.DataAccess.Repositories;

public class GameRepository : BaseRepository<Game>, IGameRepository 
{
    public GameRepository(ApplicationDbContext context ) : base(context)
    {
    } 
}
