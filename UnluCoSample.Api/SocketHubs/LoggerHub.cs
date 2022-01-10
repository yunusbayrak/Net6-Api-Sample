using Microsoft.AspNetCore.SignalR;

namespace UnluCoSample.Api.SocketHubs
{
    public class LoggerHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("GetConnectionId", this.Context.ConnectionId);            
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {            
            await base.OnDisconnectedAsync(exception);
        }
    }
}
