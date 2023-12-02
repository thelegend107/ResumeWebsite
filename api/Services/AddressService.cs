using MapDataReader;
using Microsoft.Data.SqlClient;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ResumeAPI.Services
{
    public class AddressService
    {
        private readonly SqlConnection _sqlConnection;

        public AddressService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<Address?> RetrieveAddressById(int? id)
        {
            Address? address = null;

            string sql = ObjectToSQLQueryHelper<Address>.GenerateQuery().AppendLine($"WHERE Id = {id}").ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                address = dataReader.ToAddress().FirstOrDefault();
            }

            if (address != null)
            {
                Task<Country?> countryTask = RetrieveAddressCountryById(address.CountryId);
                Task<State?> stateTask = RetrieveAddressStateById(address.StateId);

                Task.WaitAll(countryTask, stateTask);

                address.Country = countryTask.Result;
                address.State = stateTask.Result;
            }

            return address;
        }

        public async Task<Country?> RetrieveAddressCountryById(int? id)
        {
            Country? country = null;

            string sql = ObjectToSQLQueryHelper<Country>.GenerateQuery().AppendLine($"WHERE Id = {id}").ToString();


            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                country = dataReader.ToCountry().FirstOrDefault();
            }

            return country;
        }

        public async Task<State?> RetrieveAddressStateById(int? id)
        {
            State? state = null;

            string sql = ObjectToSQLQueryHelper<State>.GenerateQuery().AppendLine($"WHERE Id = {id}").ToString();


            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                state = dataReader.ToState().FirstOrDefault();
            }

            return state;
        }
    }
}
