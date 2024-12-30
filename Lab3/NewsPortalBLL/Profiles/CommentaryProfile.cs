using AutoMapper;
using NewsPortalBLL.DTO;
using NewsPortalDAL.Models;

namespace NewsPortalBLL.Profiles
{
    public class CommentaryProfile : Profile
    {
        public CommentaryProfile()
        {
            CreateMap<Commentary, CommentaryDTO>().ReverseMap();
        }
    }
}