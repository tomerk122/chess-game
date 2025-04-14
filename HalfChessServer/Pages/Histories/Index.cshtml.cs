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
    public class IndexModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public IndexModel(HalfChessServer.Data.HalfChessServerContext context)
        {
            _context = context;
        }

        public IList<History> History { get;set; } = default!;

        public async Task OnGetAsync()
        {
            History = await _context.Histories
                .Include(h => h.Player).ToListAsync();
        }
    }
}
