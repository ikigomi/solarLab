using solarLab_tt.Data;
using solarLab_tt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext appDbContext;
        private readonly BirthdayService birthdayService;

        public PersonService(AppDbContext appDbContext, BirthdayService birthdayService)
        {
            this.appDbContext = appDbContext;
            this.birthdayService = birthdayService;
        }
        public Person Create(CreatePersonRequest request)
        {
            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Birthday = request.Birthday,
                ImageUrl = request.ImgUrl

            };
            appDbContext.Person.Add(person);
            appDbContext.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            appDbContext.Person.Remove(this.Get(id));
            appDbContext.SaveChanges();
        }

        public IQueryable<Person> Get()
        {
            return appDbContext.Person;
        }

        public Person Get(int id)
        {
            return appDbContext.Person.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Person> GetUpcoming(int days)
        {
            return birthdayService.GetBirthdays(days);
        }

        public Person Update(UpdatePersonRequest request)
        {
            var person = this.Get(request.Id);
            if(person!=null)
            {
                person.FirstName = request.FirstName;
                person.LastName = request.LastName;
                person.Email = request.Email;
                person.Birthday = request.Birthday;

                appDbContext.SaveChanges();
            }
            return person;
        }
    }
}
