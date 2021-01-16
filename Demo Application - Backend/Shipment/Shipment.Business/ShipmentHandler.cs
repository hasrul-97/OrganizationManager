using Shipment.Abstraction.Business;
using Shipment.Abstraction.DataAccess;
using Shipment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Business
{
    public class ShipmentHandler : IShipmentHandler
    {
        private readonly IShipmentDataHandler _dataHandler;
        public ShipmentHandler(IShipmentDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }
        public async  Task<string> AddShipment(Shipments shipment)
        {
            return await _dataHandler.AddShipment(shipment);
        }

        public async Task<string> DeleteShipment(Shipments shipment)
        {
            return await _dataHandler.DeleteShipment(shipment);
        }

        public async Task<List<Shipments>> GetAllShipments()
        {
            return await _dataHandler.GetAllShipments();
        }

        public async Task<string> UpdateShipment(Shipments shipment)
        {
            return await _dataHandler.UpdateShipment(shipment);
        }
    }
}
