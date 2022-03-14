using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculatorDemo.Models;
using TaxCalculatorDemo.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxCalculatorDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipality _municipalityRepo;
        private readonly ITaxCalculationRule _taxCalculationRule;
        public MunicipalityController(IMunicipality municipalityRepo, ITaxCalculationRule taxCalculationRule)
        {
            _municipalityRepo = municipalityRepo;
            _taxCalculationRule = taxCalculationRule;
        }

        [HttpGet]
        public async Task<IEnumerable<Municipality>> GetMunicipalities()
        {
            return await _municipalityRepo.Get();
        }

        [HttpGet("{id}")]
        public async Task<Municipality> GetMunicipality(int id)
        {
            return await _municipalityRepo.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Municipality>> CreateMunicipality([FromBody] Municipality municipality)
        {
            var newMunicipality = await _municipalityRepo.Create(municipality);
            return CreatedAtAction(nameof(GetMunicipalities), new { id = newMunicipality.Id }, newMunicipality);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMunicipalitys(int id, [FromBody] Municipality municipality)
        {
            if (id != municipality.Id)
            {
                return BadRequest();
            }

            await _municipalityRepo.Update(municipality);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var MunicipalityToDelete = await _municipalityRepo.Get(id);
            if (MunicipalityToDelete == null)
                return NotFound();

            await _municipalityRepo.Delete(MunicipalityToDelete.Id);
            return NoContent();
        }

        [HttpGet("{id}, {taxDate}")]
        public async Task<decimal> GetTaxForDate(int id, string taxDate)
        {
            var tempTaxDate = DateTime.Parse(taxDate, new CultureInfo("da-DK"));

            var temp = await _municipalityRepo.Get(id);
            var taxRule = await _taxCalculationRule.Get(temp.TaxRule);

            decimal taxAmount = 0;
            switch (taxRule.Id)
            {
                case 1:
                    foreach (var period in taxRule.TaxPeriods)
                    {
                        if (period.Type == PeriodType.Yearly ||
                            period.Type == PeriodType.Monthly ||
                            period.Type == PeriodType.Weekly)
                        {
                            if (tempTaxDate >= period.FromDate && tempTaxDate <= period.TillDate)
                                taxAmount += period.TaxRate;
                        }
                        if (period.Type == PeriodType.Daily)
                        {
                            if (period.Dates.ToList().Where(d => d.Date == tempTaxDate) != null)
                                taxAmount += period.TaxRate;
                        }
                    }
                    break;
                case 2:
                    //Daily
                    var daylyPeriod = taxRule.TaxPeriods.FirstOrDefault(p => p.Type == PeriodType.Daily);
                    if (daylyPeriod != null
                        && daylyPeriod.Dates.ToList().FirstOrDefault(d => d.Date == tempTaxDate) != null)
                    { taxAmount = daylyPeriod.TaxRate; break; }

                    //Weekly
                    var weeklyPeriod = taxRule.TaxPeriods.FirstOrDefault(p => p.Type == PeriodType.Weekly);
                    if (weeklyPeriod != null
                        && tempTaxDate >= weeklyPeriod.FromDate && tempTaxDate <= weeklyPeriod.TillDate)
                    { taxAmount = weeklyPeriod.TaxRate; break; }

                    //Monthly
                    var monthlyPeriod = taxRule.TaxPeriods.FirstOrDefault(p => p.Type == PeriodType.Monthly);
                    if (monthlyPeriod != null
                        && tempTaxDate >= monthlyPeriod.FromDate && tempTaxDate <= monthlyPeriod.TillDate)
                    { taxAmount = monthlyPeriod.TaxRate; break; }

                    //Yearly
                    var yearlyPeriod = taxRule.TaxPeriods.FirstOrDefault(p => p.Type == PeriodType.Monthly);
                    if (yearlyPeriod != null
                        && tempTaxDate >= yearlyPeriod.FromDate && tempTaxDate <= yearlyPeriod.TillDate)
                    { taxAmount = yearlyPeriod.TaxRate; break; }

                    break;
            }
            return taxAmount;
        }
    }
}
