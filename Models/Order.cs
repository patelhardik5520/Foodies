using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [DisplayName("Date of Order")]
        [Required(ErrorMessage = "Please enter the Date Time of Order")]
        public DateTime Date { get; set; }

        [DisplayName("Address Line 1")]
        [Required(ErrorMessage = "Please enter the Shipping Address Line 1")]
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
        [Required(ErrorMessage = "Please enter the Zip Code")]
        [StringLength(6)]
        public string ZipCode { get; set; }

        [DisplayName("Shipping Address")]
        public string ShippingAddress {
            get
            {
                return AddressLine1 + " " + AddressLine2 + " " + City + " " + State + " " + ZipCode;
            } 
        }


        [DisplayName("Total Amount")]
        public decimal Total { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Additional Notes")]
        [StringLength(500)]
        public string AdditionalNote { get; set; }

        [DisplayName("Restaurant")]
        public Restaurant Restaurant { get; set; }

        [DisplayName("Restaurant Name")]
        [Required(ErrorMessage = "Please choose the Restaurant")]
        public int RestaurantId { get; set; }

        [DisplayName("Customer")]
        public Customer Customer { get; set; }

        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Please choose the Customer")]
        public int CustomerId { get; set; }

        [DisplayName("Delivery Partner")]
        public DeliveryPartner DeliveryPartner { get; set; }

        [DisplayName("Delivery Partner Name")]
        [Required(ErrorMessage = "Please choose the Delivery Partner")]
        public int DeliveryPartnerId { get; set; }
    }
}
