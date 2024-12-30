using NewsPortalBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortalBLL.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetAll();
        ClientDTO GetById(int id);
        void Add(ClientDTO commentary);
        void Update(ClientDTO commentary);
        void Delete(int id);
    }
}
