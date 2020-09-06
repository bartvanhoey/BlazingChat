using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazingChat.Client.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using BlazingChat.client;

namespace BlazingChat.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      var baseAddress = new Uri(builder.HostEnvironment.BaseAddress);

      builder.RootComponents.Add<App>("app");
      builder.Services.AddOptions();
      builder.Services.AddAuthorizationCore();

      builder.Services.AddTransient(sp => new HttpClient { BaseAddress = baseAddress });

      builder.Services.AddHttpClient<IProfileViewModel, ProfileViewModel>
        ("BlazingChatProfileClient", client => client.BaseAddress = baseAddress);

      builder.Services.AddHttpClient<IContactsViewModel, ContactsViewModel>
        ("BlazingChatContactsClient", client => client.BaseAddress = baseAddress);

      builder.Services.AddHttpClient<ISettingsViewModel, SettingsViewModel>
        ("BlazingChatSettingsClient", client => client.BaseAddress = baseAddress);

      builder.Services.AddHttpClient<ILoginViewModel, LoginViewModel>
        ("BlazingChatSettingsClient", client => client.BaseAddress = baseAddress);

      builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

      await builder.Build().RunAsync();
    }
  }
}
