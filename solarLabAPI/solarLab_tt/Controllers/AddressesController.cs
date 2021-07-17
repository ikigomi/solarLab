using Microsoft.AspNetCore.Mvc;
using solarLab_tt.Models;
using solarLab_tt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Controllers
{
    public class AddressesController : ApiController
    {
        private readonly IAddressService addressesService;

        public AddressesController(IAddressService addressService)
        {
            this.addressesService = addressService;
        }

        [HttpGet]
        public IQueryable<Address> Get()
        {
            return addressesService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public Address Get(int id)
        {
            return addressesService.Get(id);
        }

        [HttpPost]
        public Address Create(CreateAddressRequest request)
        {
            return addressesService.Create(request);
        }

        [HttpPut]
        public Address Update(UpdateAddressRequest request)
        {
            return addressesService.Update(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            addressesService.Delete(id);
        }
    }
}
