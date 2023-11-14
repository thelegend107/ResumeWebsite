using MapDataReader;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ResumeAPI.Services
{
    public class CertificateService
    {
        private readonly SqlConnection _sqlConnection;

        public CertificateService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<IEnumerable<Certificate>> RetrieveCertifcates(int userId)
        {
            List<Certificate> certificates = new List<Certificate>();

            string sql = ObjectToSQLQueryHelper<Certificate>.GenerateQuery().ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                certificates = dataReader.ToCertificate();
            }

            return certificates;
        }
    }
}
