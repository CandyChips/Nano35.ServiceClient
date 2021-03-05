using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Authorization;
using Nano35.WebClient.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Nano35.WebClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>(); 
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IRequestManager, ClusterRequestManager>();
            builder.Services.AddScoped<IInstancesService, InstancesService>();
            builder.Services.AddScoped<IInstanceService, InstanceService>();
            builder.Services.AddScoped<IWorkerService, WorkerService>();
            builder.Services.AddScoped<IUnitService, UnitService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ISessionProvider, SessionProvider>();
            builder.Services.AddSingleton<IEncryptionProvider, EncryptionProvider>();
                       
            await builder.Build().RunAsync();
        }
    }
}
