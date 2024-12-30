using AutoMapper;
using NewsPortalBLL.DTO;
using NewsPortalDAL.Models;

namespace NewsPortalBLL.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDTO>().ReverseMap();
        }
    }
}