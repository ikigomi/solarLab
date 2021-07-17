using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using solarLab_tt.Models;
using solarLab_tt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace solarLab_tt.QuartzStuff
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory schedulerFactory;
        private readonly IJobFactory jobFactory;
        private readonly IConfiguration configuration;

        public QuartzHostedService(ISchedulerFactory schedulerFactory, IJobFactory jobFactory, IConfiguration configuration)
        {
            this.schedulerFactory = schedulerFactory;
            this.jobFactory = jobFactory;
            this.configuration = configuration;
        }

        public IScheduler Scheduler { get; set; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = jobFactory;

            IJobDetail job = JobBuilder.Create<EmailSender>().Build();
            job.JobDataMap.Put("parameters", new JobUserParameters { Email = configuration.GetSection("EmailSender").GetValue<string>("Email"), Password = configuration.GetSection("EmailSender").GetValue<string>("Password") });

            //работает с запуска приложения через каждые 24 часа
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("EmailSender", "Email")
                .StartNow()
                .WithSimpleSchedule(x => x            
                    .WithIntervalInHours(24)          
                    .RepeatForever())                   
                .Build();


            //работает с 12:00 каждый день
            ITrigger trigger2 = TriggerBuilder.Create()
                .WithIdentity("EmailSender", "Email")
                .WithDailyTimeIntervalSchedule(x => x
                    .WithIntervalInHours(24)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(12, 00)))
                .Build();

            await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            await Scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler?.Shutdown(cancellationToken);
        }
    }
}
