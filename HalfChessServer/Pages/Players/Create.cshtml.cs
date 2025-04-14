using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HalfChessServer.Data;
using HalfChessServer.Models;
using System.Data;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace HalfChessServer.Pages.Players
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
        ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            var player_any = await _context.Players.Where(s => s.PlayerNumber == Player.PlayerNumber).ToListAsync();
            if (player_any.Count != 0)
            {
                ViewData["ErrorMsg"] = "There is exist Player Id, Input again Player Id!";
                ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", Player.CountryId);
                return Page();
            }
            Player.RegistedDate = DateTime.Now;
            _context.Players.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
