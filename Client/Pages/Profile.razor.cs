using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazingChat.Client.ViewModels;
using BlazingChat.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazingChat.Client.Pages
{
    public class ProfileBase : ComponentBase
    {
        [Inject] public HttpClient HttpClient { get; set; }
        protected ProfileViewModel Vm = new ProfileViewModel();
        public async Task UpdateProfileAsync()
        {
            User user = Vm;
            HttpResponseMessage httpResponseMessage = await HttpClient.PutAsJsonAsync($"api/users/{10}", user);
            Vm.Message = "Profile updated successfully";
        }

        public async Task GetProfileAsync()
        {
            Vm = await HttpClient.GetFromJsonAsync<User>($"api/users/{10}");
            Vm.Message = "Profile loaded successfully";
        }
    }
}