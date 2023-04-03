using Microsoft.EntityFrameworkCore;
using QLNH_APIs.Models;

namespace QLNH_APIs.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {

        }
        #region Dbset
  
        public DbSet<RefreshToken> RefreshTokenDBSet { get; set; }
        public DbSet<Food> FoodDBSet { get; set; }
        public DbSet<Size> SizeDBSet { get; set; }
        public DbSet<User> UserDBSet { get; set; }
        public DbSet<Item> ItemDBSet { get; set; }
        public DbSet<Category> CategoryDBSet { get; set; }
        public DbSet<Guest> GuestDBSet { get; set; }
        public DbSet<GuestTable> GuestTableDBSet { get; set; }
        public DbSet<Role> RoleDBSet { get; set; }
        public DbSet<Unit> UnitDBSet { get; set; }
        public DbSet<Status> StatusDBSet { get; set; }
        public DbSet<ItemImage> ItemImageDBSet { get; set; }
        public DbSet<Order> OrderDBSet { get; set; }
        public DbSet<OrderItem> OrderItemDBSet { get; set; }
        public DbSet<Location> LocationDBSet { get; set; }
        public DbSet<Restaurant> RestaurantDBSet { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set StudentName as concurrency column
          
        }
    }
}
