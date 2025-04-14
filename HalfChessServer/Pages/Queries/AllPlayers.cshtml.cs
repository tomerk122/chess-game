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
    public class AllPlayersModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public AllPlayersModel(HalfChessServer.Data.HalfChessServerContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Player = await (from p in _context.Players
                                 select p).Include(p => p.Country).OrderBy(p => p.Name.ToLower()).ToListAsync();
           /* Player = await _context.Players
                .Include(p => p.Country).ToListAsync();*/
        }
    }
}
