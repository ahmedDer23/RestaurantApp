using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class OrderDetail
    {
        [Key]
        public int orderDetailId { get; set; }
        public long orderMasterId { get; set; }
        public int foodItemId { get; set; }
        public FoodItem foodItem { get; set; }
        public decimal foodItemPrice { get; set; }
        public int quantity { get; set; }

    }
}
