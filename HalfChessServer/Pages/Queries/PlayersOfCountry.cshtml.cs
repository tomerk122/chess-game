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
    public class PlayersOfCountryModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public PlayersOfCountryModel(HalfChessServer.Data.HalfChessServerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Player> Players { get; set; } = default!;
        [BindProperty]
        public int SelectedCountryId { get; set; } = default!;

        public async Task OnGetAsync(int? selectedCountryId)
        {
            Players = new List<Player>();
            //Player = await _context.Players
            //    .Include(p => p.Country).ToListAsync();
            var Countries = _context.Countries
            .OrderBy(c => c.Name)
            .ToList();

            ViewData["Countries"] = new SelectList(Countries, "Id", "Name");

            if (selectedCountryId != null)
            {
                Players = await _context.Players.Where(p => p.CountryId == selectedCountryId).ToListAsync();
                SelectedCountryId = (int)selectedCountryId;
            }
            else
            {
                Players = await (from p in _context.Players select p) .ToListAsync();

            }
        }
    }
}
