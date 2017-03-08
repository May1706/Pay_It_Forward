using PayItForward.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayItForward.Data
{
    public class DataAccess
    {
        DatabaseContext _context;
        public DataAccess(DatabaseContext dbc)
        {
            _context = dbc;
        }

        public User Add(User u)
        {
            _context.Users.Add(u);
            _context.SaveChanges();
            return u;
        }
    }
}