using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RaspiDashboard.Controllers;
using UserInterface;
using RaspiDashboard.Interfaces;

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

            using (IServiceScope scope = host.Services.CreateScope())
            {
                var mainForm = scope.ServiceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }

            lifetime.StopApplication();
            await host.WaitForShutdownAsync();

        }

        static IHostBuilder CreateHostBuilder()
        {
            
            return Host.CreateDefaultBuilder().ConfigureServices((context, services) => 
            {
                services.AddTransient<MainForm>();
                services.AddTransient<IRaspiApiController, RaspiApiController>();

                var connName = context.Configuration["ConnectionName"];
                services.AddHttpClient(connName!, (s, c) =>
                {
                    
                    string portName = context.Configuration["PortNumber"]!;
                    string hostName = context.Configuration["HostName"]!;
                    string authUser = context.Configuration["AuthUser"]!;

                    if (string.IsNullOrEmpty(portName) && string.IsNullOrWhiteSpace(portName)) 
                    {
                        if (Uri.TryCreate($"{hostName}", UriKind.Absolute, out Uri? uri))
                            c.BaseAddress = uri;
                    }
                    else 
                    {
                        if(Uri.TryCreate($"{hostName}:{portName}", UriKind.Absolute, out Uri? uri))
                            c.BaseAddress = uri;
                    }
                    
                    c.DefaultRequestHeaders.Add("AUTHORIZED_USER", authUser);

                });
                  
            });
        }
    }
}