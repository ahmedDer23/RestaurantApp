using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class FoodItem
    {
        [Key]
        public int foodItemId { get; set; }
        public string foodItemName { get; set; }
        public decimal price { get; set; }
    }
}
