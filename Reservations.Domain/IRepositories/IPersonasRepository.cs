using Reservations.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Domain.IRepositories
{
    public interface IPersonasRepository
    {
        Task<IEnumerable<Persona>> GetAllPersonasAsync();
        Task<Persona> LoginPersonasAsync(string Email ,string Password);

    }
}
