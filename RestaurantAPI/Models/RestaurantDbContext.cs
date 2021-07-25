using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options): base (options)
        {

        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<OrderMaster> orderMasters { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<FoodItem> foodItems { get; set; }
    }
}
