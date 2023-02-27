using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Hrm.Interview.Infrastructure.Data
{
	public class DapperDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly IDbConnection dbConnection;

        public DapperDbContext(IConfiguration _configuration)
        {
            configuration = _configuration;
            connectionString = configuration.GetConnectionString("HrmInterviewDb");
            dbConnection = new SqlConnection(connectionString);
        }

        public IDbConnection GetConnection()
        {
            return dbConnection;
        }
    }
}

