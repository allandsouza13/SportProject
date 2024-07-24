using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity;
using SportProject.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SportProject.Data;
using SportProject.Models;

namespace SportProject.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;
        private readonly IConfiguration Configuration;
        public IndexModel(SportContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<User> Users { get; set; }

        public async Task OnGetAsync(string sortOrder,
     string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<User> usersIQ = from u in _context.Users
                                       select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                usersIQ = usersIQ.Where(u => u.LastName.Contains(searchString)
                                       || u.FirstMidName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    usersIQ = usersIQ.OrderByDescending(u => u.LastName);
                    break;
                case "Date":
                    usersIQ = usersIQ.OrderBy(u => u.EnrollmentDate);
                    break;
                case "date_desc":
                    usersIQ = usersIQ.OrderByDescending(u => u.EnrollmentDate);
                    break;
                default:
                    usersIQ = usersIQ.OrderBy(u => u.LastName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Users = await PaginatedList<User>.CreateAsync(
                usersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
