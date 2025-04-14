using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HalfChessServer.Data;
using HalfChessServer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HalfChessServer.Pages.Queries
{
    public class GamesOfPlayerModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public GamesOfPlayerModel(HalfChessServer.Data.HalfChessServerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Player> Players { get;set; } = default!;

        [BindProperty]
        public int SelectedPlayerId { get; set; } = default!;  

        public async Task OnGetAsync(int? selectedPlayerId)
        {
            Players = new List<Player>();
            //Player = await _context.Players
            //    .Include(p => p.Country).ToListAsync();
            var uniquePlayers = _context.Players
            .GroupBy(p => p.Name.ToLower())
            .Select(g => new
            {
                Id = g.First().Id,
                Name = g.Key // Use the grouped key directly for name
            })
            .OrderBy(p => p.Name)
            .ToList();

            ViewData["uniquePlayers"] = new SelectList(uniquePlayers, "Id", "Name");

            if (selectedPlayerId != null)
            {
                var players = await _context.Players.Where(p => p.Id == selectedPlayerId).ToListAsync();
                String playerName = players[0].Name.ToLower();
                Players = await _context.Players.Where(p => p.Name.ToLower() == playerName).ToListAsync();
                SelectedPlayerId = (int)selectedPlayerId;
            }
            else
            {
                Players = await (from p in _context.Players select p) .ToListAsync();

            }
        }
    }
}
