using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Quartz;
using solarLab_tt.Data;
using solarLab_tt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Services
{
    public class EmailSender : IJob
    {
        private readonly IAddressService addressService;
        private readonly BirthdayService birthdayService;

        public EmailSender(IAddressService addressService, BirthdayService birthdayService)
        {
            this.addressService = addressService;
            this.birthdayService = birthdayService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var userParameters = (JobUserParameters)context.JobDetail.JobDataMap.Get("parameters");
            var messagesList = new List<MimeMessage>();

            foreach (var address in addressService.Get())
            {
                var birthdaysList = birthdayService.GetBirthdays(address.Days);
                if (birthdaysList.Count() <= 0)
                    continue;
                var message = $"Список дней рождений на {address.Days} дней:<br>";
                foreach (var person in birthdaysList)
                {
                    message += $"Имя: {person.FirstName} {person.LastName}<br>Дата рождения: {person.Birthday}<br>Контакты: {person.Email}<br><br>";
                }

                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("Администрация сайта", userParameters.Email));
                emailMessage.To.Add(new MailboxAddress("", address.Email));
                emailMessage.Subject = "Дни рождения";
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                messagesList.Add(emailMessage);

            }


            if (messagesList.Count > 0)
            {
                using (var client = new SmtpClient())
                {
                    try
                    {
                        await client.ConnectAsync("smtp.yandex.ru", 25, false);
                        await client.AuthenticateAsync(userParameters.Email, userParameters.Password);
                        foreach (var emailMessage in messagesList)
                        {
                            await client.SendAsync(emailMessage);
                        }

                        await client.DisconnectAsync(true);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
