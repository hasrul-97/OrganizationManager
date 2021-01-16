using Metrics.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.Abstraction.DataAccess
{
    public interface IMetricsDataHandler
    {
        Task<DashboardData> GetData();
    }
}
