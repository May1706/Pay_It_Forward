using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PayItForward.Classes
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseModel")
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<DonationCenter> DonationCenter { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}