using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PayItForward.Classes
{
    public class PayItForwardContext : DbContext
    {
        public PayItForwardContext()
            : base("name=DatabaseModel")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<DonationCenter> DonationCenters { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}