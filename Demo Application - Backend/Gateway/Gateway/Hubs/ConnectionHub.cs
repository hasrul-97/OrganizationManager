using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Hubs
{
    public class ConnectionHub : Hub<Implementation>
    {
        public async Task UserAdded(string description)
        {
            await Clients.All.UserAdded(description);
        }
        public async Task UserUpdated(string description)
        {
            await Clients.All.UserUpdated(description);
        }
        public async Task ShipmentAdded(string description)
        {
            await Clients.All.ShipmentAdded(description);
        } 
        public async Task ShipmentUpdated(string description)
        {
            await Clients.All.ShipmentUpdated(description);
        }
    }

    public interface Implementation
    {
        Task UserAdded(string description);
        Task UserUpdated(string description);
        Task ShipmentAdded(string description);
        Task ShipmentUpdated(string description);
    }
}
