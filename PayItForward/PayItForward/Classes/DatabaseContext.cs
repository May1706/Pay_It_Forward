﻿using System;
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
        //public User User { get; internal set; }

        public User AddUser(User user)
        {
            this.Users.Add(user);
            this.SaveChanges();
            return user;
        }

        public int CheckForUser(String username)
        {
            int count = 0;
            try
            {
                count = this.Users.Count(u => u.Username == username);
                //check password
            }
            catch (Exception)
            {
                //handle exceptions
            }
            return count;
        }
    }
}