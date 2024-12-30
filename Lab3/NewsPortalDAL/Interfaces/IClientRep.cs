using NewsPortalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortalDAL.Interfaces
{
    public interface IClientRep
    {
        IEnumerable<Client> GetAll();
        Client GetById(int id);
        void Add(Client entity);
        void Update(Client entity);
        void Delete(Client entity);
    }
}
