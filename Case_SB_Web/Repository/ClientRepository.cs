using Case_SB_Domain;
using System;
using System.Linq;

namespace Case_SB_Web.Repository
{
    public class ClientRepository : IDisposable
    {
        private Entities _context = new Entities();

        public Client ValidateClient(string id, string secret)
        {
            return _context.Clients.Where(u => u.Id == id && u.Secret == secret).FirstOrDefault();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}