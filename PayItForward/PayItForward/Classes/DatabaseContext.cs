using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PayItForward.Classes
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseModel")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DatabaseContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DonationCenter> DonationCenters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Donation> Donations { get; set; }

        public User AddUser(User user)
        {
            this.Users.Add(user);
            this.SaveChanges();
            return user;
        }

        public Item AddItem(Item item)
        {
            this.Items.Add(item);
            this.SaveChanges();
            return item;
        }

        public Category AddCategory(Category category)
        {
            this.Categories.Add(category);
            this.SaveChanges();
            return category;
        }

        public Item GetItem(string itemName)
        {
            return Items.FirstOrDefault(item => item.Name == itemName);
        }

        public Category GetCategory(string categoryName)
        {
            return Categories.FirstOrDefault(c => c.Name == categoryName);
        }

        public DonationCenter GetCenter(string dcName)
        {
            return DonationCenters.FirstOrDefault(dc => dc.CenterName == dcName);
        }
    }
}
