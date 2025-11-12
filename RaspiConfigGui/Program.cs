using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RaspiDashboard.Controllers;
using RaspiDashboard.Models;
using System.Collections.Concurrent;
using System.Diagnostics;
using UserInterface;

namespace RaspiDashboard
{
    internal static class Program
    {
       
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();
            

            var host = CreateHostBuilder().Build();
            await host.StartAsync();
           
            IHostApplicationLifetime lifetime =
                host.Services.GetRequiredService<IHostApplicationLifetime>();

            var mainForm = host.Services.GetRequiredService<MainForm>();
            Application.ThreadException += Application_ThreadException;
            Application.Run(mainForm);

            await Task.Delay(2000);

            lifetime.StopApplication();
            await host.WaitForShutdownAsync();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Debug.WriteLine(e.ToString(), "Error");
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureServices((context, services) => 
            {
                services.AddSingleton<RaspiApiService>();
                services.AddSingleton<MainForm>();
                services.AddSingleton<ConcurrentQueue<GpioObject>>();

                var connName = context.Configuration["ConnectionName"];
               
                services.AddHttpClient(connName!, (_, c) =>
                {
                    string portNumber = context.Configuration["PortNumber"]!;
                    string hostName = context.Configuration["HostName"]!;
                    string authUser = context.Configuration["AuthUser"]!;

                    if (string.IsNullOrEmpty(portNumber) || string.IsNullOrWhiteSpace(portNumber)) 
                    {
                        Uri.TryCreate($"http://{hostName}", UriKind.Absolute, out Uri? uri);
                        c.BaseAddress = uri;
                    }
                    else 
                    {
                        Uri.TryCreate($"http://{hostName}:{portNumber}", UriKind.Absolute, out Uri? uri);
                        c.BaseAddress = uri;
                    }
                    
                    c.DefaultRequestHeaders.Add("AUTHORIZED_USER", authUser);

                });
            });
        }
    }
}