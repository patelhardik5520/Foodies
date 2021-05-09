using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Foodies.Data;
using Foodies.Models;

namespace Foodies.Pages.DeliveryPartners
{
    public class DeleteModel : PageModel
    {
        private readonly Foodies.Data.FoodiesContext _context;

        public DeleteModel(Foodies.Data.FoodiesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeliveryPartner DeliveryPartner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeliveryPartner = await _context.DeliveryPartner.FirstOrDefaultAsync(m => m.DeliveryPartnerId == id);

            if (DeliveryPartner == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeliveryPartner = await _context.DeliveryPartner.FindAsync(id);

            if (DeliveryPartner != null)
            {
                _context.DeliveryPartner.Remove(DeliveryPartner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
