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
    public class IndexModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public IndexModel(HalfChessServer.Data.HalfChessServerContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Player = await _context.Players
                .Include(p => p.Country).ToListAsync();
        }
    }
}
