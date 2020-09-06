using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace  BlazingChat.Client.Shared
{
    public class MainLayoutBase : LayoutComponentBase
    {
        [Inject] public NavigationManager NavigationManager { get; set; }       
        [Inject] public HttpClient HttpClient { get; set; }

        protected async Task LogoutUserAsync()
        {
            await HttpClient.GetAsync("api/users/logoutuser");
            NavigationManager.NavigateTo("/", true);
        }

        protected void LoginUser()
        {
            NavigationManager.NavigateTo("/", true);
        }

   
  }
}