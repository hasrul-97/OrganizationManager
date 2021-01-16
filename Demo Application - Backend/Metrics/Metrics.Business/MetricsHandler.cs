using Metrics.Abstraction.Business;
using Metrics.Abstraction.DataAccess;
using Metrics.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.Business
{
    public class MetricsHandler : IMetricsHandler
    {
        private readonly IMetricsDataHandler _handler;
        public MetricsHandler(IMetricsDataHandler handler)
        {
            _handler = handler;
        }
        public async Task<DashboardData> GetData()
        {
            return await _handler.GetData();
        }
    }
}
