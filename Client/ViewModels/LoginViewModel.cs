using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazingChat.Shared.Models;

namespace BlazingChat.Client.ViewModels
{
  public class LoginViewModel : ILoginViewModel
  {
    private readonly HttpClient _httpClient;
    public string Password { get; set; }
    public string EmailAddress { get; set; }

    public LoginViewModel()   {}

    public LoginViewModel(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task LoginUser()
    {
        var response = await _httpClient.PostAsJsonAsync<User>("api/users/loginuser", this);
    }

    public static implicit operator LoginViewModel(User user)
    {
      return new LoginViewModel
      {
        EmailAddress = user.EmailAddress,
        Password = user.Password
      };
    }

    public static implicit operator User(LoginViewModel loginViewModel)
    {
      return new User
      {
        EmailAddress = loginViewModel.EmailAddress,
        Password = loginViewModel.Password
      };
    }






  }
}