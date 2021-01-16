using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.DataAccess.Utility
{
    public class SQLQueries
    {
        public static readonly string GetUserMetrics = "SELECT COUNT(*) FROM `shipment_db`.user";
        public static readonly string GetShipmentMetrics = "SELECT COUNT(*) FROM `shipment_db`.shipment";
    }
}
