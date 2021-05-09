using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Foodies.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }

        [DisplayName("Restaurant Name")]
        [Required(ErrorMessage = "Please enter the Restaurant Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [DisplayName("Address Line 1")]
        [Required(ErrorMessage = "Please enter the Restaurant Address Line 1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "Please enter the Restaurant City")]
        [StringLength(30)]
        public string City { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "Please enter the Restaurant State")]
        [StringLength(20)]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        [Required(ErrorMessage = "Please enter the Restaurant Zip Code")]
        [StringLength(6)]
        public string ZipCode { get; set; }

        [DisplayName("Restaurant Address")]
        public string Address { 
            get
            {
                return AddressLine1 + " " + AddressLine2 + " " + City + " " + State + " " + ZipCode;
            }
        }

        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "Please enter the Restaurant Contact Number")]
        [StringLength(10)]
        [Phone]
        public string ContactNumber { get; set; }
        
        [DisplayName("License Number")]
        [Required(ErrorMessage = "Please enter the Restaurant License Number")]
        [StringLength(9)]
        public string LicenseNumber { get; set; }

        [DisplayName("Cuisine")]
        [Required(ErrorMessage = "Please choose the Restaurant Cuisine")]
        public string Cuisine { get; set; }

        [DisplayName("Rating")]
        [Required(ErrorMessage = "Please choose the Restaurant Rating")]
        [Range(1,5)]
        public int Rating { get; set; }

        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Please choose the Restaurant Start Time")]
        public TimeSpan StartTime { get; set; }

        [DisplayName("End Time")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Please choose the Restaurant End Time")]
        public TimeSpan EndTime { get; set; }
        public List<Order> Orders { get; set; }
    }
}
