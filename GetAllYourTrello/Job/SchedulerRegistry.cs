using System;
using System.Configuration;
using FluentScheduler;

namespace GetAllYourTrello.Job
{
    public class SchedulerRegistry : Registry
    {
        public SchedulerRegistry(IWorker worker)
        {
            int intervalIntegration;
            var intervalIntegrationConfig = ConfigurationManager.AppSettings["IntervalIntegration"];
            if (!int.TryParse(intervalIntegrationConfig, out intervalIntegration))
                intervalIntegration = 1;

            // https://github.com/fluentscheduler/FluentScheduler
            Schedule(() =>
            {
                try
                {
                    worker.Execute();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }).NonReentrant().ToRunNow().AndEvery(intervalIntegration).Minutes(); // Determinando a quantidade de segundos para a recorrencia do job.
        }
    }
}