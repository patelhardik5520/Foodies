using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Foodies.Data;
using Foodies.Models;

namespace Foodies.Pages.DeliveryPartners
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
        public DeliveryPartner DeliveryPartner { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeliveryPartner.Add(DeliveryPartner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
