using solarLab_tt.Data;
using solarLab_tt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Services
{
    public class AddressService : IAddressService
    {
        private readonly AppDbContext appDbContext;

        public AddressService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Address Create(CreateAddressRequest request)
        {
            var address = new Address
            {
                Email=request.Email,
                Days=request.Days
            };
            appDbContext.Addresses.Add(address);
            appDbContext.SaveChanges();
            return address;
        }

        public void Delete(int id)
        {
            appDbContext.Addresses.Remove(this.Get(id));
            appDbContext.SaveChanges();
        }

        public IQueryable<Address> Get()
        {
            return appDbContext.Addresses;
        }

        public Address Get(int id)
        {
            return appDbContext.Addresses.FirstOrDefault(x => x.Id == id);
        }

        public Address Update(UpdateAddressRequest request)
        {
            var address = this.Get(request.Id);
            if (address != null)
            {
                address.Days = request.Days;
                appDbContext.SaveChanges();
            }
            return address;
        }
    }
}
