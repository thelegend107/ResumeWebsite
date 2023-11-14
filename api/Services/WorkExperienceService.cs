﻿using MapDataReader;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI.Services
{
    public class WorkExperienceService
    {
        private readonly SqlConnection _sqlConnection;
        private readonly AddressService _addressService;

        public WorkExperienceService(SqlConnection sqlConnection, AddressService addressService)
        {
            _sqlConnection = sqlConnection;
            _addressService = addressService;
        }

        public async Task<IEnumerable<WorkExperience>> RetrieveWorkExperiences(int userId)
        {
            List<WorkExperience> workExperiences = new List<WorkExperience>();

            string sql = ObjectToSQLQueryHelper<WorkExperience>.GenerateQuery().ToString();
            
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                workExperiences = dataReader.ToWorkExperience();
            }

            Parallel.ForEach(workExperiences, workExperience =>
            {
                workExperience.Address = _addressService.RetrieveAddressById(workExperience.AddressId).Result;
                workExperience.WorkExperienceItems = RetrieveWorkExperienceItems(workExperience.Id).Result;
            });

            return workExperiences;
        }

        private async Task<IEnumerable<WorkExperienceItem>> RetrieveWorkExperienceItems(int workExperienceId)
        {
            List<WorkExperienceItem> workExperienceItems = new List<WorkExperienceItem>();

                string sql = ObjectToSQLQueryHelper<WorkExperienceItem>.GenerateQuery()
                    .AppendLine($"WHERE WorkExperienceId = {workExperienceId}")
                    .ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                workExperienceItems = dataReader.ToWorkExperienceItem();
            }

            return workExperienceItems;
        }
    }
}