using NewsPortalBLL.DTO;
using System.Collections.Generic;

namespace NewsPortalBLL.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDTO> GetAll();
        AuthorDTO GetById(int id);
        void Add(AuthorDTO user);
        void Update(AuthorDTO user);
        void Delete(int id);
    }
}