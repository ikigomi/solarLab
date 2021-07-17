using solarLab_tt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Services
{
    public interface IPersonService
    {
        public IQueryable<Person> Get();
        public IEnumerable<Person> GetUpcoming(int days);
        public Person Get(int id);
        public void Delete(int id);
        public Person Create(CreatePersonRequest request);
        public Person Update(UpdatePersonRequest request);
    }
}
