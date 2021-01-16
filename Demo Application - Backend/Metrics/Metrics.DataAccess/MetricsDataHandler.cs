using Metrics.Abstraction.DataAccess;
using Metrics.Abstraction.Repository;
using Metrics.DataAccess.Utility;
using Metrics.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.DataAccess
{
    public class MetricsDataHandler : IMetricsDataHandler
    {
        private readonly IRepositoryManager _repository;
        public MetricsDataHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public async Task<DashboardData> GetData()
        {
            try
            {
                DashboardData data = new DashboardData(await _repository.FetchData<string>(SQLQueries.GetUserMetrics), await _repository.FetchData<string>(SQLQueries.GetShipmentMetrics));
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
