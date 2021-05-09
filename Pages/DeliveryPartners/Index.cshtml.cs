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
    public class IndexModel : PageModel
    {
        private readonly Foodies.Data.FoodiesContext _context;

        public IndexModel(Foodies.Data.FoodiesContext context)
        {
            _context = context;
        }

        public IList<DeliveryPartner> DeliveryPartner { get;set; }

        public async Task OnGetAsync()
        {
            DeliveryPartner = await _context.DeliveryPartner.ToListAsync();
        }
    }
}
