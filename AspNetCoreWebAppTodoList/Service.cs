using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

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
            _webHost = new WebHostBuilder()
                .UseKestrel(options => options.ListenLocalhost(9999))
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
            _webHost.Start();
        }

        public void Stop()
        {
            _webHost.Dispose();
        }
    }
}