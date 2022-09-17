using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IClienteService
    {
        Task<Cliente> CreateCliente(Cliente cliente);
        Task<Cliente> GetClienteById(int clientId);
    }
}
