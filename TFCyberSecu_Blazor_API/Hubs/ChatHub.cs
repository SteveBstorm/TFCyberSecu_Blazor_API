using Microsoft.AspNetCore.SignalR;
using TFCyberSecu_Blazor_API.Models;

namespace TFCyberSecu_Blazor_API.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceptionMessage", message);
        }

        public async Task JoinGroup(string groupname)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
            await SendToGroup(
                new Message
                {
                    Sender = "System",
                    SendingDate = DateTime.Now,
                    IsPrivate = true,
                    Content = $"L'utilisateur portant l'id : {Context.ConnectionId}, vient de nous rejoindre"
                }, groupname);
        }

        public async Task SendToGroup(Message message, string groupname)
        {
            await Clients.Group(groupname).SendAsync("ReceptionDuGroup",message);
        }
    }
}
