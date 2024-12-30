using NewsPortalBLL.DTO;
using System.Collections.Generic;

namespace NewsPortalBLL.Interfaces
{
    public interface ICommentaryService
    {
        IEnumerable<CommentaryDTO> GetAll();
        CommentaryDTO GetById(int id);
        void Add(CommentaryDTO commentary);
        void Update(CommentaryDTO commentary);
        void Delete(int id);
    }
}