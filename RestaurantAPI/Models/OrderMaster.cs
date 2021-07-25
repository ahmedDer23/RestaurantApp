using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class OrderMaster
    {
        [Key]
        public long orderMasterId { get; set; }
        public string orderNumber { get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; }
        public string paymentMethod { get; set; }
        public decimal priceTotal { get; set; }
        public List<OrderDetail> orderDetails { get; set; }

    }
}
