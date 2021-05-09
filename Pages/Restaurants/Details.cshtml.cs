using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Foodies.Data;
using Foodies.Models;

namespace Foodies.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly Foodies.Data.FoodiesContext _context;

        public DetailsModel(Foodies.Data.FoodiesContext context)
        {
            _context = context;
        }

        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurant
                .Include(x => x.Orders)
                .FirstOrDefaultAsync(m => m.RestaurantId == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
