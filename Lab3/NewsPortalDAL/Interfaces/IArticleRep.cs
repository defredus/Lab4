using NewsPortalDAL.Models;
using NewsPortalDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortalDAL.Interfaces
{
    public interface IArticleRep : IRepository<Article>
    {
        IEnumerable<Article> GetAll();
        Article GetById(int id);
        void Add(Article entity);
        void Update(Article entity);
        void Delete(Article entity);
    }
}
