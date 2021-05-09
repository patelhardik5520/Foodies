using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Foodies.Data;
using Foodies.Models;

namespace Foodies.Pages.DeliveryPartners
{
    public class EditModel : PageModel
    {
        private readonly Foodies.Data.FoodiesContext _context;

        public EditModel(Foodies.Data.FoodiesContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeliveryPartner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryPartnerExists(DeliveryPartner.DeliveryPartnerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeliveryPartnerExists(int id)
        {
            return _context.DeliveryPartner.Any(e => e.DeliveryPartnerId == id);
        }
    }
}
