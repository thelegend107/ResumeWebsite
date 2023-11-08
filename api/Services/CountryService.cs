using api.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using MapDataReader;
using System.Data;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Services
{
    public class CountryService
    {
        private readonly SqlConnection _sqlConnection;

        public CountryService()
        {
            _sqlConnection = new SqlConnection(Environment.GetEnvironmentVariable("datawarehouseDb"));
        }

        public async Task<IEnumerable<Country>> RetrieveCountries() 
        {
            List<Country> countries = new List<Country>();

            using (_sqlConnection)
            {
                _sqlConnection.Open();
                string sql = "SELECT * FROM Countries";
                IDataReader dataReader = await new SqlCommand(sql, _sqlConnection).ExecuteReaderAsync();
                countries = dataReader.ToCountry();
            }

            return countries;
        }
    }
}
