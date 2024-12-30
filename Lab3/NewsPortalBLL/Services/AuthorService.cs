using AutoMapper;
using NewsPortalBLL.DTO;
using NewsPortalBLL.Interfaces;
using NewsPortalDAL.Interfaces;
using NewsPortalDAL.Models;
using NewsPortalDAL.Repositories;


namespace NewsPortalBLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRep _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRep userRepository, IMapper mapper)
        {
            _authorRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            try
            {
                var users = _authorRepository.GetAll();
                return _mapper.Map<IEnumerable<AuthorDTO>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all users", ex);
            }
        }

        public AuthorDTO GetById(int id)
        {
            try
            {
                var user = _authorRepository.GetById(id);
                return _mapper.Map<AuthorDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get user by ID", ex);
            }
        }

        public void Add(AuthorDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<Author>(userDTO);
                _authorRepository.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add user", ex);
            }
        }

        public void Update(AuthorDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<Author>(userDTO);
                _authorRepository.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update user", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var user = _authorRepository.GetById(id);
                if (user != null)
                {
                    _authorRepository.Delete(user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete user", ex);
            }
        }
    }
}