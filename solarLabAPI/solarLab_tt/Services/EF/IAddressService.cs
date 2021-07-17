using solarLab_tt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Services
{
    public interface IAddressService
    {
        public IQueryable<Address> Get();
        public Address Get(int id);
        public void Delete(int id);
        public Address Create(CreateAddressRequest request);

        public Address Update(UpdateAddressRequest request);
    }
}
