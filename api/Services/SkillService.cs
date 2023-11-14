﻿using MapDataReader;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ResumeAPI.Services
{
    public class SkillService
    {
        private readonly SqlConnection _sqlConnection;

        public SkillService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<IEnumerable<Skill>> RetrieveSkills(int userId)
        {
            List<Skill> skills = new List<Skill>();

            string sql = ObjectToSQLQueryHelper<Skill>.GenerateQuery().ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                skills = dataReader.ToSkill();
            }

            return skills;
        }
    }
}
