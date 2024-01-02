using Entities.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI
{
    public sealed class SocketHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(MessageSocketDto messageSocketDto)
        {
           
            await Clients.Others.SendAsync("ReceiveMessage", messageSocketDto);
        }

        public async Task SendNotification(NotificationSocketDto notificationSocket)
        {
            await Clients.Others.SendAsync("ReceiveNotification", notificationSocket);

        }

    }
}
