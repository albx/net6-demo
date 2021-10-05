using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Net6Demo.BlazorCustomElements.Wasm;
using Net6Demo.BlazorCustomElements.Wasm.Pages;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.RegisterAsCustomElement<Counter>("my-blazor-counter");
builder.RootComponents.RegisterAsCustomElement<FetchData>("fetch-data");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
