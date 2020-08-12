using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_API_DAPPER.Common
{
    public static class Global
    {
        public static string ConnectionString { get; set; }
        public static string ConnectionSQLServer { get; set; }
        public static string ConnectionOracle { get; set; }
        public static string ConnectionPostgres { get; set; }
        public static string ConnectionMySQL { get; set; }
    }
}