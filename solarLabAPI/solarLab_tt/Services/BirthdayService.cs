using solarLab_tt.Data;
using solarLab_tt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Services
{
    public class BirthdayService
    {
        private readonly AppDbContext appDbContext;

        public BirthdayService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Person> GetBirthdays(int days)
        {
            var today = DateTime.Today;
            var personList = new List<Person>();
            foreach (var client in appDbContext.Person)
            {
                var birthday = Convert.ToDateTime(client.Birthday);
                var fixedBirthday = new DateTime(today.Year, birthday.Month, birthday.Day);
                var diff = (fixedBirthday - today).Days;
                if (diff >= 0 && diff <= days)
                    personList.Add(client);
            }
            return personList;
        }
    }
}
