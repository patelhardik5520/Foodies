using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Foodies.Models;

namespace Foodies.Data
{
    public class FoodiesContext : DbContext
    {
        public FoodiesContext (DbContextOptions<FoodiesContext> options)
            : base(options)
        {
        }

        public DbSet<Foodies.Models.Restaurant> Restaurant { get; set; }

        public DbSet<Foodies.Models.Order> Order { get; set; }

        public DbSet<Foodies.Models.DeliveryPartner> DeliveryPartner { get; set; }

        public DbSet<Foodies.Models.Customer> Customer { get; set; }
    }
}
