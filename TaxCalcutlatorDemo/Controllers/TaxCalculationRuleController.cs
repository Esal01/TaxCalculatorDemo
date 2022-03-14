using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCalculatorDemo.Models;
using TaxCalculatorDemo.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxCalculatorDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculationRuleController : ControllerBase
    {
        private readonly ITaxCalculationRule _taxCalculationRuleRepo;
        public TaxCalculationRuleController(ITaxCalculationRule taxCalculationRule)
        {
            _taxCalculationRuleRepo = taxCalculationRule;
        }

        [HttpGet]
        public async Task<IEnumerable<TaxCalculationRule>> Get()
        {
            return await _taxCalculationRuleRepo.Get();
        }

        [HttpGet("{id}")]
        public async Task<TaxCalculationRule> Get(int id)
        {
            return await _taxCalculationRuleRepo.Get(id); 
        }

        [HttpPost]
        public async Task<TaxCalculationRule> Create([FromBody] TaxCalculationRule taxCalculationRule)
        {
            return await _taxCalculationRuleRepo.Create(taxCalculationRule);
        }

        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] TaxCalculationRule taxCalculationRule)
        {
            await _taxCalculationRuleRepo.Update(taxCalculationRule);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //to be implemeted
        }
    }
}
