using Microsoft.AspNetCore.Mvc;
using solarLab_tt.Models;
using solarLab_tt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Controllers
{
    public class BirthdaysController : ApiController
    {
        private readonly IPersonService clientService;

        public BirthdaysController(IPersonService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return clientService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public Person Get(int id)
        {
            return clientService.Get(id);
        }

        [HttpGet]
        [Route(nameof(GetUpcoming) + "/{days}")]
        public IEnumerable<Person> GetUpcoming(int days)
        {
            return clientService.GetUpcoming(days);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonRequest client)
        {
            return Created(nameof(Create), clientService.Create(client));
        }

        [HttpPut]
        public Person Update(UpdatePersonRequest client)
        {
            return clientService.Update(client);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            clientService.Delete(id);
            return Ok();
        }
    }
}
