using Poker.Service.DTOs.Client;

namespace Poker.Service.Interfaces.Services
{
    public interface IClientService
    {
        Task Create(ClientRequest user);
        Task<ClientResponse> GetById(int id);
        void Update(ClientUpdateRequest user);
        Task UpdateAsync(ClientUpdateRequest user);
    }
}
