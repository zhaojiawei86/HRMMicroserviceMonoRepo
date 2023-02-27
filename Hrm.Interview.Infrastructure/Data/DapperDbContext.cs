using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Hrm.Interview.Infrastructure.Data
{
	public class DapperDbContext
    {
        private readonly IDbConnection dbConnection;

        public DapperDbContext()
        {
            var connectionString = "Data Source=localhost,1433;Initial Catalog=HrmInterviewDb;User Id=sa;Password=SGF86pop;TrustServerCertificate=True";

            dbConnection = new SqlConnection(connectionString);
        }

        public IDbConnection GetConnection()
        {
            return dbConnection;
        }
    }
}

