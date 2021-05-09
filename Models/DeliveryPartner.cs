using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models
{
    public class DeliveryPartner
    {
        public int DeliveryPartnerId { get; set; }

        [DisplayName("Delivery Partner First Name")]
        [Required(ErrorMessage = "Please enter your First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Delivery Partner Last Name")]
        [Required(ErrorMessage = "Please enter your Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [DisplayName("Delivery Partner Name")]
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "Please enter your Contact Number")]
        [StringLength(10)]
        [Phone]
        public string ContactNumber { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter your Email")]
        [EmailAddress]
        public string Email { get; set; }

        public List<Order> Orders { get; set; }
    }
}
