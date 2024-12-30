using AutoMapper;
using NewsPortalBLL.DTO;
using NewsPortalBLL.Interfaces;
using NewsPortalDAL.Models;
using NewsPortalDAL.Interfaces;
using NewsPortalDAL.Repositories;
using System.Collections.Generic;

namespace NewsPortalBLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRep _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRep articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public IEnumerable<ArticleDTO> GetAll()
        {
            try
            {
                var articles = _articleRepository.GetAll();
                return _mapper.Map<IEnumerable<ArticleDTO>>(articles);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all articles", ex);
            }
        }

        public ArticleDTO GetById(int id)
        {
            try
            {
                var article = _articleRepository.GetById(id);
                return _mapper.Map<ArticleDTO>(article);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get article by ID", ex);
            }
        }

        public void Add(ArticleDTO articleDTO)
        {
            try
            {
                var article = _mapper.Map<Article>(articleDTO);
                _articleRepository.Add(article);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add article", ex);
            }
        }

        public void Update(ArticleDTO articleDTO)
        {
            try
            {
                var article = _mapper.Map<Article>(articleDTO);
                _articleRepository.Update(article);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update article", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var article = _articleRepository.GetById(id);
                if (article != null)
                {
                    _articleRepository.Delete(article);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete article", ex);
            }
        }
        public IEnumerable<ArticleDTO> GetArticleByDate(DateTime date)
        {
            try
            {
                var articles = _articleRepository.GetAll()
                    .Where(a => a.PublicationDate.Date == date.Date)
                    .ToList();

                return _mapper.Map<IEnumerable<ArticleDTO>>(articles);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get articles by date", ex);
            }
        }
    }
}