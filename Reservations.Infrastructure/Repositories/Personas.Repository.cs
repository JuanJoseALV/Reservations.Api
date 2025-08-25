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
        public async Task<Domain.Entities.Persona?> CreatePersonaAsync(Domain.Entities.Persona persona)
        {
            var existe = await _context.Personas
            .AnyAsync(p => p.Email == persona.Email || p.PasswordEmail == persona.PasswordEmail);

            if (existe)
            {
                return null;
            }

          
            var personaInfra = new InfraPersona
            {
                FirstName=persona.FirstName,
                LastName=persona.LastName,
                Employee=persona.Employee,
                StatePerson="A",
                Email = persona.Email,
                PasswordEmail = persona.PasswordEmail
            };

            _context.Personas.Add(personaInfra);
            await _context.SaveChangesAsync();

           
            return persona;
        }



        public async Task<DomainPersona?> LoginPersonasAsync(string Email, string Password)
        {
            return await _context.Personas
                .Where(x => x.Email == Email && x.PasswordEmail == Password && x.StatePerson == "A")
                .Select(x => new DomainPersona
                {
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PasswordEmail = x.PasswordEmail,
                    Employee = x.Employee,
                    StatePerson = x.StatePerson,
                    PersonId= x.PersonId,
                }).FirstOrDefaultAsync();
               
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
