using SportProject.Models;
using SportProject.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportProject.Data;
using SportProject.Models.SportViewModels;

namespace SportProject.Pages.Coaches
{
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;

        public IndexModel(SportContext context)
        {
            _context = context;
        }

        public CoachIndexData CoachData { get; set; }
        public int CoachID { get; set; }
        public int SportID { get; set; }

        public async Task OnGetAsync(int? id, int? sportID)
        {
            CoachData = new CoachIndexData();
            CoachData.Coaches = await _context.Coaches
                .OrderBy(c => c.LastName)
                .ToListAsync();

            if (id != null)
            {
                CoachID = id.Value;
                Coach coach = CoachData.Coaches
                    .Where(c => c.ID == id.Value).Single();
            }

            if (sportID != null)
            {
                SportID = sportID.Value;
                CoachData.Fixtures = await _context.Fixtures
                    .Where(f => f.SportID == SportID)
                    .ToListAsync();
            }
        }
    }
}
