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

namespace Foodies.Pages.Orders
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
        ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Name");
        ViewData["DeliveryPartnerId"] = new SelectList(_context.DeliveryPartner, "DeliveryPartnerId", "Name");
        ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "RestaurantId", "Name");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Name");
            ViewData["DeliveryPartnerId"] = new SelectList(_context.DeliveryPartner, "DeliveryPartnerId", "Name");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "RestaurantId", "Name");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var restaurantId = Order.RestaurantId;
            TimeSpan orderTime = Order.Date.TimeOfDay;
            var restaurant = await _context.Restaurant.Where(x => x.RestaurantId == restaurantId).ToListAsync();
            TimeSpan restaurantStartTime = restaurant[0].StartTime;
            TimeSpan restaurantEndTime = restaurant[0].EndTime;
            if ((orderTime < restaurantStartTime) || (orderTime > restaurantEndTime))
            {
                ModelState.AddModelError("Order.Date", "The Order Time should be within Restaurant Start Time and End Time");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
