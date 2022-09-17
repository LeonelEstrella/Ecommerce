using Application.Interfaces.Command;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class ClienteCommand : IClienteCommand
    {
        private readonly AppDbContext _context;

        public ClienteCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertCliente(Cliente cliente)
        {
            _context.Add(cliente);

            await _context.SaveChangesAsync();
        }
    }
}
