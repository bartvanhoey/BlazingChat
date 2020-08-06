using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazingChat.Shared.Models;

namespace BlazingChat.Client.ViewModels
{
  public class SettingsViewModel : ISettingsViewModel
  {
    public bool Notifications { get; set; }
    public bool DarkTheme { get; set; }
    private readonly HttpClient _httpClient;

    public SettingsViewModel(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public SettingsViewModel() { }

    public async Task GetProfileAsync()
    {
      var user = await _httpClient.GetFromJsonAsync<User>("api/users/getprofile/10");
      LoadCurrentObject(user);
    }

    private void LoadCurrentObject(SettingsViewModel settingsViewModel)
    {
      DarkTheme = settingsViewModel.DarkTheme;
      Notifications = settingsViewModel.Notifications;
    }

    public async Task SaveAsync()
    {
      await _httpClient.GetFromJsonAsync<User>($"api/users/updateTheme?userId={10}&value={DarkTheme.ToString()}");
      await _httpClient.GetFromJsonAsync<User>($"api/users/updatenotifications?userId={10}&value={Notifications.ToString()}");
    }

    public static implicit operator SettingsViewModel(User user)
    {
      return new SettingsViewModel
      {
        Notifications = (user.Notifications == null || (long)user.Notifications == 0) ? false : true,
        DarkTheme = (user.DarkTheme == null || (long)user.DarkTheme == 0) ? false : true
      };
    }

    public static implicit operator User(SettingsViewModel settingsViewModel)
    {
      return new User
      {
        Notifications = settingsViewModel.Notifications ? 1 : 0,
        DarkTheme = settingsViewModel.DarkTheme ? 1 : 0
      };
    }
  }
}