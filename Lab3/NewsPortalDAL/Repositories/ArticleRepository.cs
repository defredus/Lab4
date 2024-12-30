using NewsPortalDAL.Models;
using NewsPortalDAL.Interfaces;
using NewsPortalDAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NewsPortalDAL.Repositories
{
    public class ArticleRepository : IArticleRep
    {
        private readonly NewsPortalContext _context;

        public ArticleRepository(NewsPortalContext context)
        {
            _context = context;
        }

        public IEnumerable<Article> GetAll()
        {
            try
            {
                return _context.Articles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all articles from repository", ex);
            }
        }

        public Article GetById(int id)
        {
            try
            {
                return _context.Articles.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get article by ID from repository", ex);
            }
        }

        public void Add(Article entity)
        {
            try
            {
                _context.Articles.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add article to repository", ex);
            }
        }

        public void Update(Article entity)
        {
            try
            {
                _context.Articles.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update article in repository", ex);
            }
        }

        public void Delete(Article entity)
        {
            try
            {
                _context.Articles.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete article from repository", ex);
            }
        }
    }
}