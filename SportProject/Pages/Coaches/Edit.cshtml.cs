using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportProject.Data;
using SportProject.Models;

namespace SportProject.Pages.Coaches
{
    public class EditModel : PageModel
    {
        private readonly SportContext _context;

        public EditModel(SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coach Coach { get; set; } = default!;

        // This property will hold the list of available coaches for selection
        public List<SelectListItem> CoachSelectList { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coaches == null)
            {
                return NotFound();
            }

            // Retrieve the coach with the specified ID
            Coach = await _context.Coaches
                .AsNoTracking() // Optimize performance for read-only queries
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Coach == null)
            {
                return NotFound();
            }

            // Populate the CoachSelectList
            CoachSelectList = await _context.Coaches
                .Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.FullName // Ensure FullName is a property
                })
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Repopulate the CoachSelectList in case of validation errors
                CoachSelectList = await _context.Coaches
                    .Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.FullName // Ensure FullName is a property
                    })
                    .ToListAsync();

                return Page();
            }

            // Use Update method for existing entities
            _context.Coaches.Update(Coach);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachExists(Coach.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw; // Rethrow the exception if the coach still exists
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CoachExists(int id)
        {
            return _context.Coaches.Any(e => e.ID == id);
        }
    }
}
