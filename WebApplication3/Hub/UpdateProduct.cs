using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebApplication3.Hubs
{


    public class ProductHub : Hub
    {
        public async Task SendProductUpdate()
        {
            await Clients.All.SendAsync("UpdateProducts");
        }
    }
}