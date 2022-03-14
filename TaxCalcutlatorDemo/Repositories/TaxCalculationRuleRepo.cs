using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCalculatorDemo.Models;

namespace TaxCalculatorDemo.Repositories
{
    public class TaxCalculationRuleRepo : ITaxCalculationRule
    {

        private readonly ApplicationDbContext _context;

        public TaxCalculationRuleRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaxCalculationRule> Create(TaxCalculationRule taxCalculationRule)
        {
            _context.TaxCalculationRules.Add(taxCalculationRule);
            await _context.SaveChangesAsync();
            return taxCalculationRule;
        }

        public async Task Delete(int id)
        {
            var tempTaxCalculationRule =await _context.TaxCalculationRules.FindAsync(id);
            _context.TaxCalculationRules.Remove(tempTaxCalculationRule);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaxCalculationRule>> Get()
        {
            return await _context.TaxCalculationRules.Include(t => t.TaxPeriods)
                                                     .ThenInclude(p =>p.Dates).ToListAsync();
        }

        public async Task<TaxCalculationRule> Get(int id)
        {
            var taxCalculationRule = await _context.TaxCalculationRules
                        .SingleAsync(b => b.Id == id);

            await _context.Entry(taxCalculationRule)
                          .Collection(b => b.TaxPeriods)
                          .LoadAsync();
            foreach (var period in taxCalculationRule.TaxPeriods)
            {
                await _context.Entry(period)
                              .Collection(b => b.Dates)
                              .LoadAsync();
            }

            return taxCalculationRule;
        }

        public async Task Update(TaxCalculationRule taxCalculationRule)
        {
            _context.Entry(taxCalculationRule).State =  EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
