using Microsoft.AspNetCore.SignalR;

namespace TFCyberSecu_Blazor_API.Hubs
{
    public class ArticleHub : Hub
    {
        public async Task NotifyNewArticle()
        {
            Clients.All.SendAsync("newArticle");
        }
    }
}
