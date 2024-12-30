using NewsPortalDAL.Repositories;
using NewsPortalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortalDAL.Interfaces
{
    public interface IAuthorRep : IRepository<Author>
    {
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        void Add(Author entity);
        void Update(Author entity);
        void Delete(Author entity);
    }
}
