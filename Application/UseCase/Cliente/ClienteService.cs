using Application.Interfaces.Command;
using Application.Interfaces.Query;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.UseCase
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteCommand _command;
        private readonly IClienteQuery _query;

        public ClienteService()
            //:this ()
        {
               
        }

        public ClienteService(IClienteCommand clienteCommand, IClienteQuery clienteQuery)
        {
            _command = clienteCommand;
            _query = clienteQuery;
        }

        public async Task<Cliente> CreateCliente(Cliente cliente)
        {
            _command.InsertCliente(cliente);
            return cliente;//esto hay que sacarlo
            //throw new NotImplementedException();
        }

        public Task<Cliente> GetClienteById(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
