using Shipment.Abstraction.DataAccess;
using Shipment.Abstraction.Repository;
using Shipment.DataAccess.Utility;
using Shipment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.DataAccess
{
    public class ShipmentDataHandler : IShipmentDataHandler
    {
        private readonly IRepositoryManager _repository;
        public ShipmentDataHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public async Task<string> AddShipment(Shipments shipment)
        {
            try
            {
                int numberOfRowsAffected = await _repository.AddToDatabaseWithParameter(SQLQueries.AddShipment, shipment);
                if (numberOfRowsAffected > 0)
                {
                    return "Shipment inserted successfully";
                }
                else
                {
                    throw new Exception("An error occured while adding shipment");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteShipment(Shipments shipment)
        {
            try
            {
                int numberOfRowsAffected = await _repository.DeleteWithParameter(SQLQueries.DeleteShipment, shipment);
                if (numberOfRowsAffected > 0)
                {
                    return "Shipment deleted successfully";
                }
                else
                {
                    throw new Exception("An error occured while deleting shipment");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Shipments>> GetAllShipments()
        {
            try
            {
                return await _repository.FetchList<Shipments>(SQLQueries.GetAllShipments);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdateShipment(Shipments shipment)
        {
            try
            {
                int numberOfRowsAffected = await _repository.UpdateWithParameter(SQLQueries.UpdateShipment, shipment);
                if (numberOfRowsAffected > 0)
                {
                    return "Shipment updated successfully";
                }
                else
                {
                    throw new Exception("An error occured while updating shipment");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
