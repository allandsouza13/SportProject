using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportProject.Data;
using SportProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportProject.Pages.Sports
{
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;

        public IndexModel(SportContext context)
        {
            _context = context;
        }

        public IList<SportViewModel> SportVM { get; set; }

        public async Task OnGetAsync()
        {
            SportVM = await _context.Sports
                .Select(s => new SportViewModel
                {
                    SportID = s.SportID,
                    Name = s.Name,
                    Description = s.Description
                })
                .ToListAsync();
        }
    }
}
