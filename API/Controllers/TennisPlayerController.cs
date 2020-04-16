using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TennisPlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public TennisPlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IEnumerable<Player>> Get()
        {
            var players = await _playerService.GetAllPlayers();
            return players.OrderBy(e => e.id).ToList();
        }

        [HttpGet]
        [Route("[action]/{playerId}")]
        public async Task<ActionResult> GetPlayerById(int playerId)
        {
            if (playerId == 0)
                return BadRequest();

            var players = await _playerService.GetAllPlayers();

            var expectedPlayer = players.Where(e => e.id == playerId).FirstOrDefault();

            if (expectedPlayer == null)
              return NotFound();
            
            
            return Ok(expectedPlayer);
            
        }
    }
}
