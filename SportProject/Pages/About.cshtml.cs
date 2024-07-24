using SportProject.Models.SchoolViewModels;
using SportProject.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportProject.Models;

namespace SportProject.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SportContext _context;

        public AboutModel(SportContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Users { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                from User in _context.Users
                group User by User.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    UserCount = dateGroup.Count()
                };

            Users = await data.AsNoTracking().ToListAsync();
        }
    }
}