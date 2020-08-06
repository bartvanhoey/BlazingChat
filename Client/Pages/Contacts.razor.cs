using System.Threading.Tasks;
using BlazingChat.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazingChat.Client.Pages
{
    public class ContactsBase : ComponentBase
    {
        [Inject] public IContactsViewModel Vm { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
           await Vm.GetContactsAsync();
        }

        protected void NavigateToChat() {
            NavigationManager.NavigateTo("/chat");
        }
        
    }
}