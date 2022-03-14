using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCalculatorDemo.Models;

namespace TaxCalculatorDemo.Repositories
{
    public class MunicipalityRepo : IMunicipality
    {
        private readonly ApplicationDbContext _context; 
        private readonly ILogger _logger;

        public MunicipalityRepo(ApplicationDbContext context, ILogger<MunicipalityRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Municipality> Create(Municipality municipality)
        {
            _context.Municipalities.Add(municipality);
            await _context.SaveChangesAsync();
            return municipality;
        }

        public async Task Delete(int id)
        {
            var municipality = await _context.Municipalities.FindAsync(id);
            _context.Municipalities.Remove(municipality);
            await _context.SaveChangesAsync();
        }

        public async Task<Municipality> Get(int id)
        {
            _logger.LogInformation($"Get methode called for municipility with parameter id = {id} ");
            return await _context.Municipalities.FindAsync(id);
        }

        public async Task<IEnumerable<Municipality>> Get()
        {
            return await _context.Municipalities.ToListAsync();
        }

        public async Task Update(Municipality municipality)
        {
            _context.Entry(municipality).State = EntityState.Modified;  
            await _context.SaveChangesAsync();  
        }
    }
}
