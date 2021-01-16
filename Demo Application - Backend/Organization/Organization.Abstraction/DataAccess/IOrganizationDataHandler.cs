using Organization.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Abstraction.DataAccess
{
    public interface IOrganizationDataHandler
    {
        Task<List<User>> GetAllUser();
        Task<string> AddUser(User user);
        Task<string> UpdateUser(User user);
        Task<string> DeleteUser(User user);
    }
}
