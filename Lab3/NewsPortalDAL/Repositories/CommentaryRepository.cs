using NewsPortalDAL.Interfaces;
using NewsPortalDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace NewsPortalDAL.Repositories
{
    public class CommentaryRepository : ICommentaryRep
    {
        private readonly NewsPortalContext _context;

        public CommentaryRepository(NewsPortalContext context)
        {
            _context = context;
        }

        public IEnumerable<Commentary> GetAll()
        {
            try
            {
                return _context.Comments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all commentaries from repository", ex);
            }
        }

        public Commentary GetById(int id)
        {
            try
            {
                return _context.Comments.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get commentary by ID from repository", ex);
            }
        }

        public void Add(Commentary entity)
        {
            try
            {
                _context.Comments.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add commentary to repository", ex);
            }
        }

        public void Update(Commentary entity)
        {
            try
            {
                _context.Comments.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update commentary in repository", ex);
            }
        }

        public void Delete(Commentary entity)
        {
            try
            {
                _context.Comments.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete commentary from repository", ex);
            }
        }
    }
}