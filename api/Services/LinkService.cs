using MapDataReader;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ResumeAPI.Services
{
    public class LinkService
    {
        private readonly SqlConnection _sqlConnection;

        public LinkService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<IEnumerable<Link>> RetrieveLinks(int userId)
        {
            List<Link> links = new List<Link>();

            string sql = ObjectToSQLQueryHelper<Link>.GenerateQuery().ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                links = dataReader.ToLink();
            }

            return links;
        }
    }
}
