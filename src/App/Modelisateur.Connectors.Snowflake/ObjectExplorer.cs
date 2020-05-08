using Modelisateur.Connectors.Snowflake.Models;
using Snowflake.Data.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Modelisateur.Connectors.Snowflake
{
    public class ObjectExplorer : IDisposable
    {
        private SnowflakeDbConnection _connection;

        public ObjectExplorer(string account, string user, System.Security.SecureString password, string host)
        {
            _connection = new SnowflakeDbConnection();
            _connection.ConnectionString = ConnectionStringUtility.GetConnectionString(account, user, host);
            _connection.Password = password;
            _connection.Open();
        }
        public IList<Database> GetDatabases()
        {
            List<Database> databases = new List<Database>();
            IDbCommand cmd = _connection.CreateCommand();
            cmd.CommandText = @"SELECT DATABASE_NAME FROM UTIL_DB.INFORMATION_SCHEMA.DATABASES";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                databases.Add(GetDatabase(reader.GetString(0)));
            }

            return databases;
        }

        public Database GetDatabase(string dbName)
        {
            var database = new Database() { Name = dbName };
            IDbCommand cmd = _connection.CreateCommand();
            cmd.CommandText = $@"SELECT T.TABLE_SCHEMA, T.TABLE_NAME, C.COLUMN_NAME, DATA_TYPE
                                FROM {dbName}.INFORMATION_SCHEMA.TABLES AS T
                                INNER JOIN {dbName}.INFORMATION_SCHEMA.COLUMNS AS C
                                ON T.TABLE_NAME = C.TABLE_NAME";
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var schema = database.Schemas.FirstOrDefault(o => o.Name == reader.GetString(0));
                if (schema == null)
                {
                    schema = new Schema()
                    {
                        Database = database,
                        Name = reader.GetString(0)
                    };
                    database.Schemas.Add(schema);
                }

                var table = schema.Tables.FirstOrDefault(o => o.Name == reader.GetString(1));
                if(table == null)
                {
                    table = new Table()
                    {
                        Database = database,
                        Schema = new Schema() { Database = database, Name = reader.GetString(0) },
                        Name = reader.GetString(1),
                    };
                    schema.Tables.Add(table);
                }

                table.Columns.Add(new Column(table)
                {
                    Name = reader.GetString(2),
                    Type = reader.GetString(3)
                });
            }

            return database;
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
