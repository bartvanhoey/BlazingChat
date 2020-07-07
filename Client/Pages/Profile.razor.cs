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
       // protected ProfileViewModel Vm = new ProfileViewModel();
       
    }
}