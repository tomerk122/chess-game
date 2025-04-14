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
    public class DeleteModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public DeleteModel(HalfChessServer.Data.HalfChessServerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public History History { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories.FirstOrDefaultAsync(m => m.Id == id);

            if (history == null)
            {
                return NotFound();
            }
            else
            {
                History = history;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories.FindAsync(id);
            if (history != null)
            {
                History = history;
                _context.Histories.Remove(History);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
