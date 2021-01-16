using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Models
{
    public class DashboardData
    {
        public string Users { get; set; }
        public string Shipments { get; set; }
        public DashboardData(string users, string shipments)
        {
            Users = users;
            Shipments = shipments;
        }
    }
}
