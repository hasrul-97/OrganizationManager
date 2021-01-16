using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.DataAccess.Utility
{
    public class SQLQueries
    {
        public static readonly string GetAllUser = "SELECT * FROM `user`;";
        public static readonly string AddUser = "INSERT INTO `user`(`UserID`,`Name`,`Gender`,`Email`,`Job`)VALUES" +
            "(@UserID,@Name,@Gender,@Email,@Job); ";
        public static readonly string UpdateUser = "UPDATE `user` SET `Name` = @Name,`Gender` = @Gender,`Email` = @Email,`Job` = @Job WHERE `UserID` = @UserID;";
        public static readonly string DeleteUser = "DELETE FROM `user` WHERE `UserID`    = @UserID;";
    }
}