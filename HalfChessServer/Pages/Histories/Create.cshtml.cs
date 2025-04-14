using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HalfChessServer.Data;
using HalfChessServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HalfChessServer.Pages.Histories
{
    public class CreateModel : PageModel
    {
        private readonly HalfChessServer.Data.HalfChessServerContext _context;

        public CreateModel(HalfChessServer.Data.HalfChessServerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public History History { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Player? player = await _context.Players.FindAsync(History.PlayerId);
            // increase player game quantity
            player.Quantity += 1;
            // set country is played by any player
            Country? country = await _context.Countries.FindAsync(player.CountryId);
            country.IsPlayer = true;

            _context.Entry(country).State = EntityState.Modified;
            _context.Entry(player).State = EntityState.Modified;

            if(History.AtFrom ==null) History.AtFrom = DateTime.Now;
            _context.Histories.Add(History);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
