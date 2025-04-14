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
    public class LastGameModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public LastGameModel(HalfChessServer.Data.HalfChessServerContext context)
        {
            _context = context;
        }

        public IList<LastGameView> History { get;set; } = default!;

        public async Task OnGetAsync()
        {
            History = await (from p in _context.Players
                          orderby p.Name descending
                          select new LastGameView() { Name = p.Name, LastPlayDate = p.Histories.Max(h => h.AtFrom) }).ToListAsync();
           // History = await _context.Histories.Include(h => h.Player).ToListAsync();
        }
    }
}
