using System;
using Topshelf;

namespace AspNetCoreWebAppTodoList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var host = HostFactory.Run(
                h =>
                {
                    h.Service<Service>(
                        s =>
                        {
                            try
                            {
                                s.ConstructUsing(name => new Service());
                                s.WhenStarted(StartService);
                                s.WhenStopped(StopService);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                        }
                    );
                    h.RunAsLocalSystem();

                    h.SetDescription("REST interface for todo items.");
                    h.SetDisplayName("My Awesome REST-APi");
                    h.SetServiceName("My Awesome REST-APi");
                    h.UseLog4Net(Constants.Log4NetConfigFile, true);
                }
            );
            if (host == TopshelfExitCode.ServiceAlreadyRunning) Console.WriteLine("Service is already running");
        }

        private static void StopService(Service service)
        {
            try
            {
                service.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception starting service", ex);
                throw;
            }
        }

        private static void StartService(Service service)
        {
            try
            {
                service.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception starting service", ex);
                throw;
            }
        }
    }
}