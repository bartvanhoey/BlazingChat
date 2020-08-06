using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazingChat.Shared.Models;

namespace BlazingChat.Client.ViewModels
{
  public class ProfileViewModel : IProfileViewModel
  {
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Message { get; set; }
    private readonly HttpClient httpClient;

    public ProfileViewModel() { }

    public ProfileViewModel(HttpClient http)
    {
      this.httpClient = http;
    }

    public async Task UpdateProfileAsync()
    {
      User user = this;
      HttpResponseMessage httpResponseMessage = await httpClient.PutAsJsonAsync($"api/users/updateprofile/{10}", user);
      this.Message = "Profile updated successfully";
    }

    public async Task GetProfileAsync()
    {
      User user = await httpClient.GetFromJsonAsync<User>($"api/users/getprofile/{10}");
      LoadCurrentObject(user);
      this.Message = "Profile loaded successfully";
    }

    public static implicit operator ProfileViewModel(User user)
    {
      return new ProfileViewModel
      {
        FirstName = user.FirstName,
        LastName = user.LastName,
        EmailAddress = user.EmailAddress,
        UserId = user.UserId
      };
    }


    public static implicit operator User(ProfileViewModel profileViewModel)
    {
      return new User
      {
        FirstName = profileViewModel.FirstName,
        LastName = profileViewModel.LastName,
        EmailAddress = profileViewModel.EmailAddress,
        UserId = profileViewModel.UserId
      };
    }

    private void LoadCurrentObject(ProfileViewModel _)
    {
      FirstName = _.FirstName;
      LastName = _.LastName;
      EmailAddress = _.EmailAddress;
    }

  }
}