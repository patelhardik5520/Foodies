using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [DisplayName("Customer First Name")]
        [Required(ErrorMessage="Please enter your First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Customer Last Name")]
        [Required(ErrorMessage = "Please enter your Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [DisplayName("Name")]
        public string Name { 
            get {
                return FirstName + " " + LastName;
            } 
        }

        [DisplayName("Customer Address")]
        public string Address
        {
            get
            {
                return AddressLine1 + " " + AddressLine2 + " " + City + " " + State + " " + ZipCode;
            }
        }


        [DisplayName("Address Line 1")]
        [Required(ErrorMessage = "Please enter your Address Line 1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "Please enter the City")]
        [StringLength(30)]
        public string City { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "Please enter the State")]
        [StringLength(20)]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        [Required(ErrorMessage = "Please enter your Zip Code")]
        [StringLength(6)]
        public string ZipCode { get; set; }

        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "Please enter your Contact Number")]
        [StringLength(10)]
        [Phone]
        public string ContactNumber { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter the Email")]
        [EmailAddress]
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
    }
}
