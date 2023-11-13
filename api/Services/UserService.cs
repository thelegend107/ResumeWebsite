using ResumeAPI.Helpers;
using ResumeAPI.Models;
using System;
using System.Data;
using System.Data.SqlClient;
#nullable enable
using System.Threading.Tasks;
using MapDataReader;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ResumeAPI.Services
{
    public class UserService
    {
        private readonly SqlConnection _sqlConnection;

        public UserService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<User?> RetrieveUserById(int Id)
        {
            User? user = null;
            string sql = ObjectToSQLQueryHelper<User>.GenerateQuery().AppendLine($"WHERE Id = {Id}").ToString();

            try
            {
                using (_sqlConnection)
                {
                    _sqlConnection.Open();
                    IDataReader dataReader = await new SqlCommand(sql, _sqlConnection).ExecuteReaderAsync();
                    user = dataReader.ToUser().FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }
    }
}
