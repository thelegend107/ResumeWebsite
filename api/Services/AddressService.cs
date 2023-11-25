using MapDataReader;
using Microsoft.Data.SqlClient;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System.Data;
using System.Linq;
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

            return address;
        }
    }
}
