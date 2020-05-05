using Case_SB_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case_SB_Web.Repository
{
    public class UserRepository : IDisposable
    {
        private Entities _context = new Entities();

        public User ValidateUser(string name, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && u.Password == password);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}