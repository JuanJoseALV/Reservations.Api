using Microsoft.EntityFrameworkCore;
using Reservations.Domain.IRepositories;
using InfraPersona = Reservations.Infrastructure.Persistence.Models.Persona;
using DomainPersona = Reservations.Domain.Entities.Persona;
using InfraDbContext = Reservations.Infrastructure.Persistence.Models.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Infrastructure.Repositories
{
    public class Personas : IPersonasRepository
    {
        private readonly InfraDbContext _context;

        public Personas(InfraDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DomainPersona>> GetAllPersonasAsync()
        {
            return await _context.Personas
       .Select(p => new DomainPersona
       {
           PersonId = p.PersonId,
           FirstName = p.FirstName,
           LastName = p.LastName,
           Email = p.Email,
           Employee = p.Employee,
           StatePerson = p.StatePerson,
       })
       .ToListAsync();
        }

    }
}
