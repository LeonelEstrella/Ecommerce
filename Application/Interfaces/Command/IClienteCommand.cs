using Domain.Entities;

namespace Application.Interfaces.Command
{
    public interface IClienteCommand
    {
        Task InsertCliente(Cliente cliente);
    }
}
