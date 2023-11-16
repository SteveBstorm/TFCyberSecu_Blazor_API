using Microsoft.AspNetCore.SignalR;

namespace TFCyberSecu_Blazor_API.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceptionMessage", message);
        }

        public async Task JoinGroup(string groupname)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
        }

        public async Task SendToGroup(string message, string groupname)
        {
            await Clients.Group(groupname).SendAsync("ReceptionDuGroup",message);
        }
    }
}
