using Organization.Abstraction.DataAccess;
using Organization.Abstraction.Repository;
using Organization.DataAccess.Utility;
using Organization.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Organization.DataAccess
{
    public class OrganizationDataHandler : IOrganizationDataHandler
    {
        private readonly IRepositoryManager _repository;
        public OrganizationDataHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public async Task<string> AddUser(User user)
        {
            try
            {
                int numberOfRowsAffected = await _repository.AddToDatabaseWithParameter(SQLQueries.AddUser, user);
                if (numberOfRowsAffected > 0)
                {
                    return "User added successfully";
                }
                else
                {
                    throw new Exception("An error has occured while adding user");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteUser(User user)
        {
            try
            {
                int numberOfRowsAffected = await _repository.DeleteWithParameter(SQLQueries.DeleteUser, user);
                if (numberOfRowsAffected > 0)
                {
                    return "User deleted successfully";
                }
                else
                {
                    throw new Exception("An error has occured while deleting user");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            try
            {
                return await _repository.FetchList<User>(SQLQueries.GetAllUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdateUser(User user)
        {
            try
            {
                int numberOfRowsAffected = await _repository.UpdateWithParameter(SQLQueries.UpdateUser, user);
                if (numberOfRowsAffected > 0)
                {
                    return "User updated successfully";
                }
                else
                {
                    throw new Exception("An error has occured while updating user");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
