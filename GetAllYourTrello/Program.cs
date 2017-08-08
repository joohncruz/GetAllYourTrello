using GetAllYourTrello.Core;
using GetAllYourTrello.Job;
using Topshelf;

namespace GetAllYourTrello
{
    class Program
    {
        static void Main(string[] args)
        {
            // para instalar: C:\>XXXX.exe install start
            // https://github.com/Topshelf/Topshelf
            HostFactory.Run(x =>
            {
                x.Service<Main>(s =>
                {
                    // Como no construtor da nossa classe Main precisamos passar um Scheduler 
                    // onde controla a repetição que é preciso passar o Worker, que possui o codigo a ser executado
                    s.ConstructUsing(name => new Main(new SchedulerRegistry(new Worker())));
                    s.WhenStarted(m => m.Start());
                    s.WhenStopped(m => m.Stop());
                });

                x.RunAsNetworkService();
                x.SetDescription(Constants.JobDescription);
                x.SetDisplayName(Constants.JobName);
                x.SetServiceName(Constants.JobName);
                x.StartAutomatically();

                // Caso o serviço pare ele irá reiniciar novamente.
                x.EnableServiceRecovery(r =>
                {
                    r.RestartService(1);
                    r.RestartService(2);
                });
            });
        }
    }
}
