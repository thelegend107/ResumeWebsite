using MapDataReader;
using Microsoft.Data.SqlClient;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ResumeAPI.Services
{
    public class FileService
    {
        private readonly SqlConnection _sqlConnection;

        public FileService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }


        public async Task<IEnumerable<File>> RetrieveFiles(int userId)
        {
            List<File> files = new List<File>();

            string sql = ObjectToSQLQueryHelper<File>.GenerateQuery().ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                files = dataReader.ToFile();
            }

            return files;
        }
    }
}
