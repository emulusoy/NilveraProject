using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
namespace NilveraProject.Infrastructure.Data
{
    public class NilveraContext
    {
        private readonly string _conn;
        public NilveraContext(IConfiguration config)
        {
            _conn = config.GetConnectionString("SqlServer")!;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_conn);
    }
}
