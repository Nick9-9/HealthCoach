using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HealthCoach.Client.Services.Contract;
using HealthCoach.Client.Services.Implementation;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using HealthCoach.Client.Helpers;

namespace HealthCoach.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredLocalStorage();

           
            builder.Services.AddScoped<ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<ApiAuthenticationStateProvider>());
            builder.Services.AddScoped<IAuthService, AuthService>();
            //builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

            

            await builder.Build().RunAsync();
        }
        
    }
}
