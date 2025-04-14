using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HalfChessServer.Data;
using HalfChessServer.Models;

namespace HalfChessServer.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public DetailsModel(HalfChessServer.Data.HalfChessServerContext context)
        {
            _context = context;
        }

        public Player Player { get; set; } = default!;

       public async Task<IActionResult> OnGetAsync(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    // Use Include to load the Country property along with the Player
    Player = await _context.Players
        .Include(p => p.Country) // This will include the Country entity
        .FirstOrDefaultAsync(m => m.Id == id);

    if (Player == null)
    {
        return NotFound();
    }

    return Page();
}

    }
}
