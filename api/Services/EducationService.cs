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
    public class EducationService
    {
        private readonly SqlConnection _sqlConnection;
        private readonly AddressService _addressService;

        public EducationService(SqlConnection sqlConnection, AddressService addressService)
        {
            _sqlConnection = sqlConnection;
            _addressService = addressService;
        }

        public async Task<IEnumerable<Education>> RetrieveEducations(int userId)
        {
            List<Education> educations = new List<Education>();

            string sql = ObjectToSQLQueryHelper<Education>.GenerateQuery().ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                educations = dataReader.ToEducation();
            }

            Parallel.ForEach(educations, education =>
            {
                education.Address = _addressService.RetrieveAddressById(education.AddressId).Result;
                education.EducationItems = RetrieveEducationItems(education.Id).Result;
            });

            return educations;
        }

        private async Task<IEnumerable<EducationItem>> RetrieveEducationItems(int educationId)
        {
            List<EducationItem> educationItems = new List<EducationItem>();

            string sql = ObjectToSQLQueryHelper<EducationItem>.GenerateQuery()
                .AppendLine($"WHERE EducationId = {educationId}")
                .ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                educationItems = dataReader.ToEducationItem();
            }

            return educationItems;
        }
    }
}
