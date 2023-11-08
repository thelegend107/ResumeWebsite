using api.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using MapDataReader;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

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
                string sql = @"
                    SELECT
                         [Id]
                        --,[RegionId]
                        --,[SubRegionId]
                        ,[Name]
                        ,[NativeName]
                        ,[ISO3]
                        ,[ISO2]
                        ,[NumericCode]
                        ,[PhoneCode]
                        ,[Capital]
                        ,[Currency]
                        ,[CurrencyName]
                        ,[CurrencySymbol]
                        ,[Tld]
                        ,[Latitude]
                        ,[Longitude]
                        ,[Emoji]
                    FROM [dbo].[Country]
                ";
                IDataReader dataReader = await new SqlCommand(sql, _sqlConnection).ExecuteReaderAsync();
                countries = dataReader.ToCountry();
            }

            return countries;
        }

        public async Task<IEnumerable<State>> RetrieveStatesByISO2CountryCode(string ISO2)
        {
            List<State> states = new List<State>();

            using (_sqlConnection)
            {
                _sqlConnection.Open();
                
                // Retrieve Country Id
                string countryIdSql = $"SELECT TOP (1) [Id] FROM Country WHERE ISO2 = '{ISO2}'";
                SqlDataReader countryDataReader = await new SqlCommand(countryIdSql, _sqlConnection).ExecuteReaderAsync();
                bool countryIsValid = countryDataReader.HasRows;

                Country country = countryDataReader.ToCountry().FirstOrDefault();
                countryDataReader.Close();

                // Retrieve Country States
                if (countryIsValid)
                {
                    string sql = @$"
                        SELECT 
                             [Id]
                            --,[CountryId]
                            ,[StateCode]
                            ,[Name]
                            ,[Latitude]
                            ,[Longitude]
                        FROM [dbo].[State]
                        WHERE CountryId = '{country.Id}'
                    ";

                    IDataReader stateDataReader = await new SqlCommand(sql, _sqlConnection).ExecuteReaderAsync();
                    states = stateDataReader.ToState();
                    stateDataReader.Close();
                }
            }

            return states;
        }
    }
}
