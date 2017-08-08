using System;
using FluentScheduler;
using GetAllYourTrello.Job;

namespace GetAllYourTrello
{
    public class Main : Registry
    {
        private readonly SchedulerRegistry _registry;

        public Main(SchedulerRegistry registry)
        {
            _registry = registry;
        }
        public void Start()
        {
            JobManager.Initialize(_registry);
        }
        public void Stop()
        {
            Console.WriteLine("Parando o serviço");
        }
    }
}
