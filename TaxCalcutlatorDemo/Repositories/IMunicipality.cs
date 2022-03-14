using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCalculatorDemo.Models;

namespace TaxCalculatorDemo.Repositories
{
    public interface IMunicipality
    {
        Task<IEnumerable<Municipality>> Get();
        Task<Municipality> Get(int id);
        Task<Municipality> Create(Municipality municipality);
        Task Update(Municipality municipality);
        Task Delete(int id);  

    }
}
