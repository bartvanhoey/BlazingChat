using System.Threading.Tasks;
using BlazingChat.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazingChat.Client.Pages
{
    public class LoginBase : ComponentBase
    {
        [Inject] public NavigationManager NavigationManager { get; set; }   
        [Inject] public ILoginViewModel LoginViewModel { get; set; }

        protected async Task LoginUser()
        {
            await LoginViewModel.LoginUser();
            NavigationManager.NavigateTo("/profile", true);
        }
    }
}