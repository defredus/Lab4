using NewsPortalDAL.Interfaces;
using NewsPortalDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace NewsPortalDAL.Repositories
{
    public class ClientRepository : IClientRep
    {
        private readonly NewsPortalContext _context;

        public ClientRepository(NewsPortalContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAll()
        {
            try
            {
                return _context.Clients.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all commentaries from repository", ex);
            }
        }

        public Client GetById(int id)
        {
            try
            {
                return _context.Clients.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get commentary by ID from repository", ex);
            }
        }

        public void Add(Client entity)
        {
            try
            {
                _context.Clients.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add commentary to repository", ex);
            }
        }

        public void Update(Client entity)
        {
            try
            {
                _context.Clients.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update commentary in repository", ex);
            }
        }

        public void Delete(Client entity)
        {
            try
            {
                _context.Clients.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete commentary from repository", ex);
            }
        }
    }
}