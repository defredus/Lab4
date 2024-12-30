using NewsPortalDAL.Interfaces;
using NewsPortalDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace NewsPortalDAL.Repositories
{
    public class AuthorRepository : IAuthorRep
    {
        private readonly NewsPortalContext _context;

        public AuthorRepository(NewsPortalContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            try
            {
                return _context.Authors.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all users from repository", ex);
            }
        }

        public Author GetById(int id)
        {
            try
            {
                return _context.Authors.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get user by ID from repository", ex);
            }
        }

        public void Add(Author entity)
        {
            try
            {
                _context.Authors.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add user to repository", ex);
            }
        }

        public void Update(Author entity)
        {
            try
            {
                _context.Authors.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update user in repository", ex);
            }
        }

        public void Delete(Author entity)
        {
            try
            {
                _context.Authors.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete user from repository", ex);
            }
        }
    }
}