using System.Threading.Tasks;
using BlazingChat.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace BlazingChat.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.Users(new[] { message.ToUserId, message.FromUserId }).SendAsync("ReceiveMessage", message);
        }
    }
}