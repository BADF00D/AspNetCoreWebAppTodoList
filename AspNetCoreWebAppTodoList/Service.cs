using System;
using System.IO;
using AspNetCoreWebAppTodoList.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetCoreWebAppTodoList
{
    internal class Service : IDisposable
    {
        private IWebHost _webHost;

        public void Dispose()
        {
            _webHost?.Dispose();
        }

        public void Start()
        {
            var log4NetProvider = new Log4NetProvider("log4net.config");
            _webHost = new WebHostBuilder()
                .UseKestrel(options => options.ListenLocalhost(9999))
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .ConfigureLogging((hc, log) => log.AddProvider(log4NetProvider))
                .Build();
            _webHost.Start();
        }

        public void Stop()
        {
            _webHost.Dispose();
        }
    }
}