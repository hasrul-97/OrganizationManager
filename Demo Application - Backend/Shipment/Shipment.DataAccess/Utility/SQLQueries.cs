using System;
using System.Collections.Generic;
using System.Text;

namespace Shipment.DataAccess.Utility
{
    public class SQLQueries
    {
        #region Shipment
        public static readonly string GetAllShipments = "SELECT * FROM shipment;";
        public static readonly string AddShipment = "INSERT INTO shipment(`ID`,`Name`,`Type`,`Pickup_Pincode`,`Drop_Pincode`)VALUES" +
            "(@ID,@Name,@Type,@Pickup_Pincode,@Drop_Pincode); ";
        public static readonly string UpdateShipment = "UPDATE `shipment` SET `Name` = @Name,`Type` = @Type,`Pickup_Pincode` = @Pickup_Pincode,`Drop_Pincode` = @Drop_Pincode WHERE `ID` = @ID";
        public static readonly string DeleteShipment = "DELETE FROM shipment WHERE `ID` = @ID";

        #endregion
    }
}
