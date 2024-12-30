using NewsPortalBLL.Interfaces;

namespace Lab3
{
    public class ServiceStorage
    {
        public IArticleService articleService { get; set; }
        public ICommentaryService commentaryService { get; set; }
        public IAuthorService authorService { get; set; }
        public IClientService clientService { get; set; }

        public ServiceStorage(IArticleService articleService, ICommentaryService commentaryService,
                                IAuthorService authorService, IClientService clientService)
        {
            this.articleService = articleService;
            this.commentaryService = commentaryService;
            this.authorService = authorService;
            this.clientService = clientService;
        }
    }
}
