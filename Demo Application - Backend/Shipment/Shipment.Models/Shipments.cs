using System;
using System.Collections.Generic;
using System.Text;

namespace Shipment.Models
{
    public class Shipments
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Pickup_Pincode { get; set; }
        public string Drop_Pincode { get; set; }
    }
}
