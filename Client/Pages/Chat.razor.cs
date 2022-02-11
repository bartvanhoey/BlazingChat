using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazingChat.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

namespace BlazingChat.Client.Pages
{
    public partial class Chat
    {
        // @inject HttpClient Http
        //     @inject IJSRuntime JSRuntime
        // @inject HttpClient _httpClient

        [Inject] public HttpClient HttpClient { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [CascadingParameter] public Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Parameter] public string ToUserId { get; set; }
        public User ToUser { get; set; } = new();
        public string FromUserId { get; set; }
        public string MessageText { get; set; }
        public List<Message> Messages { get; set; } = new();
        
        protected HubConnection HubConnection;


        protected override async Task OnInitializedAsync()
        {
            var claimsPrincipal = (await AuthenticationStateTask).User;

            if (!claimsPrincipal.Identity!.IsAuthenticated) NavigationManager.NavigateTo("/");

            FromUserId  = (await HttpClient.GetFromJsonAsync<User>("user/getcurrentuser"))?.UserId.ToString();

            if (long.Parse(ToUserId) > 0)
                ToUser = await HttpClient.GetFromJsonAsync<User>($"user/getprofile/{ToUserId}");


            HubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/chathub")).Build();

            HubConnection.On<Message>("ReceiveMessage", (message) =>
            {
                Messages.Add(message);
                StateHasChanged();
            });

            await HubConnection.StartAsync();

        }

        
        private async Task Send()
        {
            var message = new Message { ToUserId = ToUserId, FromUserId = FromUserId, MessageText = MessageText };
            await HubConnection.SendAsync("SendMessage", message);
        }
    }
}