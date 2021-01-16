using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Shipment.Abstraction.Business;
using Shipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly HubConnection _hubConnection;
        private readonly IShipmentHandler _shipment;
        public ShipmentController(IShipmentHandler shipment, IConfiguration configuration)
        {
            _shipment = shipment;
            _hubConnection = new HubConnectionBuilder().WithUrl(configuration.GetSection("hub").Value).Build();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _shipment.GetAllShipments());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Shipments shipment)
        {
            string response = await _shipment.AddShipment(shipment);
            if (!string.IsNullOrEmpty(response))
            {
                await SendPulse("ShipmentAdded", string.Format("A new shipment has been added: {0}", shipment.Name));
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Shipments shipment)
        {
            string response = await _shipment.UpdateShipment(shipment);
            if (!string.IsNullOrEmpty(response))
            {
                await SendPulse("ShipmentUpdated", string.Format("A shipment has been updated: {0}", shipment.Name));
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Shipments shipment)
        {
            string response = await _shipment.DeleteShipment(shipment);
            if (!string.IsNullOrEmpty(response))
            {
                await SendPulse("ShipmentDeleted", string.Format("A shipment has been deleted: {0}", shipment.Name));
            }
            return Ok(response);
        }

        public async Task SendPulse(string method, string description)
        {
            await _hubConnection.StartAsync();
            await _hubConnection.InvokeAsync(method, description);
            await _hubConnection.DisposeAsync();
        }
    }
}
