using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportProject.Models;
using SportProject.Data;

namespace SportProject.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly SportProject.Data.SportContext _context;

        public EditModel(SportProject.Data.SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var UserToUpdate = await _context.Users.FindAsync(id);

            if (UserToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<User>(
                UserToUpdate,
                "User",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool UserExists(int id)
        {
          return _context.Users.Any(e => e.ID == id);
        }
    }
}
