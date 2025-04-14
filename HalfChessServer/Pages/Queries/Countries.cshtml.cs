using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HalfChessServer.Data;
using HalfChessServer.Models;

namespace HalfChessServer.Pages.Queries
{
    public class CountriesModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public CountriesModel(HalfChessServer.Data.HalfChessServerContext context)
        {
            _context = context;
        }

        public IList<History> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Player = await _context.Histories
                .Include(h => h.Player) // Include Player details
                .Include(h => h.Player.Country) // Include Country details for the Player
                .GroupBy(h => h.Player.CountryId) // Group by the Country ID of the Players
                .Select(g => g.OrderByDescending(i => i.AtFrom).First()) // Select the latest history per country
                .ToListAsync(); // Execute the query and get the results
        }
    }
}
