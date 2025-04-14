using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HalfChessServer.Data;
using HalfChessServer.Models;

namespace HalfChessServer.Pages.Histories
{
    public class DetailsModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public DetailsModel(HalfChessServer.Data.HalfChessServerContext context)
        {
            _context = context;
        }

        public History History { get; set; } = default!;
        public string PlayerName { get; set; } = string.Empty; // Property for Player Name

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the history record
            History = await _context.Histories.FirstOrDefaultAsync(m => m.Id == id);
            if (History == null)
            {
                return NotFound();
            }

            // Fetch the player's name based on PlayerId
            var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == History.PlayerId);
            if (player != null)
            {
                PlayerName = player.Name; // Set the PlayerName property
            }

            return Page();
        }
    }
}
