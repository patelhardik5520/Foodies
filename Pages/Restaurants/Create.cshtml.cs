using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Foodies.Data;
using Foodies.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodies.Pages.Restaurants
{
    public class CreateModel : PageModel
    {
        private readonly Foodies.Data.FoodiesContext _context;

        public CreateModel(Foodies.Data.FoodiesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TimeSpan duration = Restaurant.EndTime.Subtract(Restaurant.StartTime);
            if (TimeSpan.Compare(duration, TimeSpan.Zero) <= 0)
            {
                ModelState.AddModelError("Restaurant.EndTime", "The Restaurant End Time can not be less or equal to than Start Time");
            }
            var licenseNumber = Restaurant.LicenseNumber;
            bool licenseNumberAlreadyExists = await _context.Restaurant.AnyAsync(x => x.LicenseNumber == licenseNumber);

            if (licenseNumberAlreadyExists)
            {
                ModelState.AddModelError("Restaurant.LicenceNumber", "Restaurant with this license Number already exists");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Restaurant.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
