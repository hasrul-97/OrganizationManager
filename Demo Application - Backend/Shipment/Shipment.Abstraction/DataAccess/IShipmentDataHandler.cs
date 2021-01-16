using Shipment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Abstraction.DataAccess
{
    public interface IShipmentDataHandler
    {
        Task<List<Shipments>> GetAllShipments();
        Task<string> AddShipment(Shipments shipment);
        Task<string> UpdateShipment(Shipments shipment);
        Task<string> DeleteShipment(Shipments shipment);
    }
}
