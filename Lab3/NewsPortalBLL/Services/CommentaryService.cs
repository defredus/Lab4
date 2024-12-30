using AutoMapper;
using NewsPortalBLL.DTO;
using NewsPortalBLL.Interfaces;
using NewsPortalDAL.Interfaces;
using NewsPortalDAL.Models;


namespace NewsPortalBLL.Services
{
    public class CommentaryService : ICommentaryService
    {
        private readonly ICommentaryRep _commentaryRepository;
        private readonly IMapper _mapper;

        public CommentaryService(ICommentaryRep commentaryRepository, IMapper mapper)
        {
            _commentaryRepository = commentaryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CommentaryDTO> GetAll()
        {
            try
            {
                var commentaries = _commentaryRepository.GetAll();
                return _mapper.Map<IEnumerable<CommentaryDTO>>(commentaries);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all commentaries", ex);
            }
        }

        public CommentaryDTO GetById(int id)
        {
            try
            {
                var commentary = _commentaryRepository.GetById(id);
                return _mapper.Map<CommentaryDTO>(commentary);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get commentary by ID", ex);
            }
        }

        public void Add(CommentaryDTO commentaryDTO)
        {
            try
            {
                var commentary = _mapper.Map<Commentary>(commentaryDTO);
                _commentaryRepository.Add(commentary);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add commentary", ex);
            }
        }

        public void Update(CommentaryDTO commentaryDTO)
        {
            try
            {
                var commentary = _mapper.Map<Commentary>(commentaryDTO);
                _commentaryRepository.Update(commentary);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update commentary", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var commentary = _commentaryRepository.GetById(id);
                if (commentary != null)
                {
                    _commentaryRepository.Delete(commentary);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete commentary", ex);
            }
        }
    }
}