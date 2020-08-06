using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazingChat.Client.ViewModels;

namespace BlazingChat.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {


      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("app");

      var baseAddress = new Uri(builder.HostEnvironment.BaseAddress);

      builder.Services.AddHttpClient<IProfileViewModel, ProfileViewModel>("BlazingChatProfileClient", client
        => client.BaseAddress = baseAddress);

      builder.Services.AddHttpClient<IContactsViewModel, ContactsViewModel>("BlazingChatContactsClient", client
        => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

        builder.Services.AddHttpClient<ISettingsViewModel, SettingsViewModel>("BlazingChatSettingsClient", client 
        => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

      await builder.Build().RunAsync();
    }
  }
}
