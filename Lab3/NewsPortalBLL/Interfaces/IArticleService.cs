using NewsPortalBLL.DTO;

namespace NewsPortalBLL.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<ArticleDTO> GetAll();
        ArticleDTO GetById(int id);
        void Add(ArticleDTO article);
        void Update(ArticleDTO article);
        void Delete(int id);
        IEnumerable<ArticleDTO> GetArticleByDate(DateTime date);
    } 
}