using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HalfChessServer.Data;
using HalfChessServer.Models;

namespace HalfChessServer.Pages.Histories
{
    public class EditModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public EditModel(HalfChessServer.Data.HalfChessServerContext context)
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

            var history =  await _context.Histories.FirstOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }
            History = history;
           ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(History).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryExists(History.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HistoryExists(int id)
        {
            return _context.Histories.Any(e => e.Id == id);
        }
    }
}
