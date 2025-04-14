using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HalfChessServer.Data;
using HalfChessServer.Models;
using Microsoft.AspNetCore.Authorization;
using HalfChessServer.Api.Game;

namespace HalfChessServer.Api
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly HalfChessServerContext _context;

        public GamesController(HalfChessServerContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<History>>> GetHistories()
        {
            return await _context.Histories.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<History>> GetHistory(int id)
        {
            var history = await _context.Histories.FindAsync(id);

            if (history == null)
            {
                return NotFound();
            }

            return history;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginData loginData)
        {
            //fetch the list of players with the given PlayerNumber
            var players = await _context.Players
                .Where(p => p.PlayerNumber == loginData.PlayerId)
                .ToListAsync();

            // Perform a case-sensitive comparison on the player names
            var playerMatch = players.FirstOrDefault(p => p.Name == loginData.PlayerName);

            if (playerMatch != null)
            {
                return Ok("Login successful");
            }
            return NotFound("noExist");
        }
        [HttpPost("start")]
        // POST: api/Games/start
        // starting game only first
        public async Task<IActionResult> Start([FromBody] History startGameRequest)
        {
            var playerList = await _context.Players.Where(p => p.PlayerNumber == startGameRequest.PlayerId).ToListAsync();
            if (playerList.Count == 0)
                return BadRequest(new { state = "incorrect playerId" });
            // set player id
            Player player = playerList[0];
            startGameRequest.PlayerId = player.Id;
            // increase player game quantity
            player.Quantity += 1;
            // set country is played by any player
            Country? country = await _context.Countries.FindAsync(player.CountryId);
            country.IsPlayer = true;

            _context.Entry(country).State = EntityState.Modified;
            _context.Entry(player).State = EntityState.Modified;

            startGameRequest.AtFrom = DateTime.Now;
            _context.Histories.Add(startGameRequest);
            await _context.SaveChangesAsync();

            return Ok(startGameRequest.Id.ToString());
        }

        [HttpPost("end")]
        // PUT: api/Games/5
        //// end game
        public async Task<IActionResult> End([FromBody] History endGameRequest)
        {

            History? history = await _context.Histories.FindAsync(endGameRequest.Id);
            if (history == null)
                return NotFound("no exist History");
            if (history.AtTo != null)
                return NotFound("the game is aleady ended.");

            if (endGameRequest.Result != null)
            {
                history.AtTo = DateTime.Now;
                history.Result = endGameRequest.Result;
            }
            _context.Entry(history).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryExists(endGameRequest.Id))
                {
                    return NotFound("no exist History");
                }
                else
                {
                    throw;
                }
            }
            return Ok("Game ended");
        }

        [HttpPost("move")]
        public async Task<IActionResult> Move([FromBody] object arg)
        {
            string JsonChessState = arg?.ToString();

            Game.Game game = new Game.Game();
            game.LoadBoard(JsonChessState);

            Random random = new Random();

            if (random.Next(1, 250) <= 10) // can be delay.
            {
                int delayMilliseconds = random.Next(0, 10) * 1000; // ערכים מ-0 עד 3 שניות
                await Task.Delay(delayMilliseconds);
            }

            Move randMove = game.GetRandomMove(SideType.Black);
            return Ok(randMove);
        }

        private bool HistoryExists(int id)
        {
            return _context.Histories.Any(e => e.Id == id);
        }
        // POST: api/Games/promote
        [HttpPost("promote")]
        public IActionResult Promote([FromBody] dynamic promotionRequest)
        {


            // Randomly select a piece type (2 = Rook, 3 = Bishop, 4 = Knight)
            Random random = new Random();
            int promoPieceType = random.Next(2, 4); 

            return Ok(promoPieceType); 
        }

        [HttpGet("game-ids")]
        public async Task<ActionResult<IEnumerable<int>>> GetGameIds()
        {
            // Retrieve only the IDs of all the games in the Histories table
            var gameIds = await _context.Histories.Select(h => h.Id).ToListAsync();
            return Ok(gameIds);
        }


    }

}

