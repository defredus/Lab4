using AutoMapper;
using NewsPortalBLL.DTO;
using NewsPortalBLL.Interfaces;
using NewsPortalDAL.Models;
using NewsPortalDAL.Interfaces;
using NewsPortalDAL.Repositories;
using System.Collections.Generic;

namespace NewsPortalBLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRep _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRep clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            try
            {
                var clients = _clientRepository.GetAll();
                return _mapper.Map<IEnumerable<ClientDTO>>(clients);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all articles", ex);
            }
        }

        public ClientDTO GetById(int id)
        {
            try
            {
                var client = _clientRepository.GetById(id);
                return _mapper.Map<ClientDTO>(client);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get article by ID", ex);
            }
        }

        public void Add(ClientDTO clientDTO)
        {
            try
            {
                var client = _mapper.Map<Client>(clientDTO);
                _clientRepository.Add(client);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add client", ex);
            }
        }

        public void Update(ClientDTO clientDTO)
        {
            try
            {
                var client = _mapper.Map<Client>(clientDTO);
                _clientRepository.Update(client);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update client", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var client = _clientRepository.GetById(id);
                if (client != null)
                {
                    _clientRepository.Delete(client);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete article", ex);
            }
        }
    }
}