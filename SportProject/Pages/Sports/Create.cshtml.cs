using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SportProject.Data;
using SportProject.Models;

namespace SportProject.Pages.Sports
{
    public class CreateModel : PageModel
    {
        private readonly SportContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(SportContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Sport Sport { get; set; }

        // This method handles the POST request to create a new Sport
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid. Check the data entered: {Errors}", ModelState.Values);
                return Page(); // Return the same page to show validation errors
            }

            try
            {
                _context.Sports.Add(Sport);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Sport with ID {SportId} added successfully. Redirecting to Index page.", Sport.SportID);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the sport with Name: {SportName}.", Sport.Name);
                // Provide feedback to the user
                ModelState.AddModelError(string.Empty, "An error occurred while saving the sport. Please try again later.");
                return Page(); // Return the same page with error message
            }
        }
    }
}
