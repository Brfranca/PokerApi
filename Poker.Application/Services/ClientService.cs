using Poker.Service.DTOs.Client;
using Poker.Service.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service.Services
{
    public class ClientService : IClientService
    {
        public Task Create(ClientRequest user)
        {
            throw new NotImplementedException();
        }

        public Task<ClientResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientUpdateRequest user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ClientUpdateRequest user)
        {
            throw new NotImplementedException();
        }
    }
}
