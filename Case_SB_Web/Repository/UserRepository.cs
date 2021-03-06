﻿using Case_SB_Domain;
using System;
using System.Linq;

namespace Case_SB_Web.Repository
{
    public class UserRepository : IDisposable
    {
        private Entities _context = new Entities();

        public User ValidateUser(string name, string password)
        {
            return _context.Users.Where(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && u.Password == password).FirstOrDefault();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}