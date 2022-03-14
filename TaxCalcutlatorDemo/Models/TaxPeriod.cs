using System;
using System.Collections.Generic;

namespace TaxCalculatorDemo.Models
{
    public class TaxPeriod
    {
        public int Id { get; set; }
        public PeriodType Type { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime TillDate { get; set; }
        public decimal TaxRate { get; set; }

        //public virtual TaxCalculationRule TaxCalculationRule { get; set; }
        public virtual List<Dates> Dates { get; set; }


    }

    public class Dates
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //public virtual TaxPeriod TaxPeriod { get; set; }

    }

    public enum PeriodType
    {
        Yearly = 1,
        Monthly = 2,
        Weekly= 3,
        Daily =4
    }
}