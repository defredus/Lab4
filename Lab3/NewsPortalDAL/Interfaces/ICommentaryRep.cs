using NewsPortalDAL.Models;
using NewsPortalDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortalDAL.Interfaces
{
    public interface ICommentaryRep: IRepository<Commentary>
    {
        IEnumerable<Commentary> GetAll();
        Commentary GetById(int id);
        void Add(Commentary entity);
        void Update(Commentary entity);
        void Delete(Commentary entity);
    }
}
