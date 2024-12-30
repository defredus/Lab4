using AutoMapper;
using NewsPortalBLL.DTO;
using NewsPortalDAL.Models;

namespace NewsPortalBLL.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
        }
    }
}