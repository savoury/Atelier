using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPlayerService
{
    Task<List<Player>> GetAllPlayers();
}