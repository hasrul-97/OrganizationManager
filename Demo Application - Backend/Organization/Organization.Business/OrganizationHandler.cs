using Organization.Abstraction.Business;
using Organization.Abstraction.DataAccess;
using Organization.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Business
{
    public class OrganizationHandler : IOrganizationHandler
    {
        private readonly IOrganizationDataHandler _organizationDataHandler;
        public OrganizationHandler(IOrganizationDataHandler organizationDataHandler)
        {
            _organizationDataHandler = organizationDataHandler;
        }

        public async Task<string> AddUser(User user)
        {
            return await _organizationDataHandler.AddUser(user);
        }

        public async Task<string> DeleteUser(User user)
        {
            return await _organizationDataHandler.DeleteUser(user);
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _organizationDataHandler.GetAllUser();
        }

        public async Task<string> UpdateUser(User user)
        {
            return await _organizationDataHandler.UpdateUser(user);
        }
    }
}
