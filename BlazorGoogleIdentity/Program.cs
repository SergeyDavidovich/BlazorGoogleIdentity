using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// https://chandradev819.wordpress.com/2021/03/22/google-authentication-and-authorization-in-blazor-webassembly/
// https://console.cloud.google.com/apis/credentials?project=api-6572864239938239592-574458
// https://stackoverflow.com/questions/66083740/google-auth-error-getting-access-token-in-blazor/66139736#66139736
// https://developers.google.com/identity/protocols/oauth2/javascript-implicit-flow


namespace BlazorGoogleIdentity
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("web", options.ProviderOptions);

            });

            await builder.Build().RunAsync();
        }
    }
}
