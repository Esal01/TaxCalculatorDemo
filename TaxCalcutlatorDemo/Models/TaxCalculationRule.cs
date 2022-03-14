using System.Collections.Generic;

namespace TaxCalculatorDemo.Models
{
    public class TaxCalculationRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<TaxPeriod> TaxPeriods { get; set; }
    }
}
