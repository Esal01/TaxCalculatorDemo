using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCalculatorDemo.Models;

namespace TaxCalculatorDemo.Repositories
{
    public interface ITaxCalculationRule
    {

        Task<IEnumerable<TaxCalculationRule>> Get();
        Task<TaxCalculationRule> Get(int id);
        Task<TaxCalculationRule> Create(TaxCalculationRule taxCalculationRule);
        Task Update(TaxCalculationRule taxCalculationRule);
        Task Delete(int id);
    }
}
