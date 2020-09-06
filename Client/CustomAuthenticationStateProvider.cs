using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazingChat.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazingChat.client
{
  public class CustomAuthenticationStateProvider : AuthenticationStateProvider
  {
    private readonly HttpClient _httpClient;

    public CustomAuthenticationStateProvider(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }


    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      var currentUser = await _httpClient.GetFromJsonAsync<User>("api/users/getcurrentuser");

      if (currentUser != null && currentUser.EmailAddress != null)
      {
         var claim = new Claim(ClaimTypes.Name, currentUser.EmailAddress);
        var claimsIdentity = new ClaimsIdentity(new[] {claim}, "sertverAuth"); 
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
      
        return new AuthenticationState(claimsPrincipal);
      }
      else
      {
          return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
      }
      
    }
  }
}