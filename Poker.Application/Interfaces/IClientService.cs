using Poker.Service.DTOs.Client;
using Poker.Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service.Interfaces
{
    public interface IClientService
    {
        Task Create(ClientRequest user);
        Task<ClientResponse> GetById(int id);
        void Update(ClientUpdateRequest user);
        Task UpdateAsync(ClientUpdateRequest user);
    }
}
