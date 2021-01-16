using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Abstraction.Repository
{
    public interface IRepositoryManager
    {
        Task<int> AddToDatabase(string sqlQuery);
        Task<int> AddToDatabaseWithParameter(string sqlQuery, object parameter);
        Task<int> AddToDatabaseBulkWithParameter<T>(string sqlQuery, List<T> parameter);
        Task<T> FetchData<T>(string sqlQuery);
        Task<T> FetchDataWithParameter<T>(string sqlQuery, object parameter);
        Task<List<T>> FetchList<T>(string sqlQuery);
        Task<List<T>> FetchListWithParameter<T>(string sqlQuery, object parameter);
        Task<int> Update(string sqlQuery);
        Task<int> UpdateWithParameter(string sqlQuery, object parameter);
        Task<int> Delete(string sqlQuery);
        Task<int> DeleteWithParameter(string sqlQuery, object parameter);
    }
}
