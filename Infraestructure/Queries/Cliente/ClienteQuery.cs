using Application.Interfaces.Query;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Queries
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly AppDbContext _context;

        public ClienteQuery(AppDbContext context)
        {
            _context = context;
        }

        public Cliente GetClienteById(int clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
