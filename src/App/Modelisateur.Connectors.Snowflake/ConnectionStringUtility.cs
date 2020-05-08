using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Connectors.Snowflake
{
    internal static class ConnectionStringUtility
    {
        public static string GetConnectionString(string account, string user, string host)
        {
            return GetConnectionString(account, user, host, "UTIL_DB", "INFORMATION_SCHEMA");
        }
        public static string GetConnectionString(string account, string user, string host, string dbName, string schema)
        {
            return string.Join(";", $"account={account}", $"user={user}", "WAREHOUSE=DEMO_WH", $"db={dbName}", $"schema={schema}",
                "HOST=pocia.canada-central.azure.snowflakecomputing.com");
        }
    }
}
