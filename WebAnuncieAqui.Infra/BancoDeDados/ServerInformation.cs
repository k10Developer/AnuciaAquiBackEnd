using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace WebAnuciaAqui.Infra.BancoDeDados
{
    public class ServerInformation
    {
        public ServerInformation(DbType dbType, string server, string database, string userId, string password)
        {
            this.DatabaseType = dbType;
            this.Server = server;
            this.Database = database;
            this.UserId = userId;
            this.Password = password;
            Validated();
        }

        public ServerInformation(DbType dbType, string server, string database, string userId, string password, int port)
            : this(dbType, server, database, userId, password)
        {
            this.Port = port;
        }

        public ServerInformation(DbType dbType, string connectionString)
        {
            this.DatabaseType = dbType;

            var serverInfo = GetServerInformation(dbType, connectionString);
            this.Server = serverInfo.Server;
            this.Database = serverInfo.Database;
            this.UserId = serverInfo.UserId;
            this.Password = serverInfo.Password;
            this.Port = serverInfo.Port;
        }

        private bool IsPostgres()
        {
            return this.DatabaseType == DbType.Postgress;
        }


        private ServerInformation GetServerInformation(DbType dbType, string connectionstring)
        {
            DbConnectionStringBuilder dbConnectionStringBuilder = GetStringBuilder(connectionstring);

            var server = IsPostgres() ? dbConnectionStringBuilder["host"].ToString() : dbConnectionStringBuilder["server"].ToString();
            var databaseName = dbConnectionStringBuilder["database"].ToString();
            var user = dbConnectionStringBuilder["user id"].ToString();
            var password = dbConnectionStringBuilder["password"].ToString();
            return new ServerInformation(dbType, server, databaseName,
                user, password);
        }

        private DbConnectionStringBuilder GetStringBuilder(string connectionstring)
        {
            switch (this.DatabaseType)
            {
                case DbType.SqlServer:
                    return new System.Data.SqlClient.SqlConnectionStringBuilder(connectionstring);
                case DbType.Postgress:
                    return new Npgsql.NpgsqlConnectionStringBuilder(connectionstring);
                case DbType.SAPHana:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }

        public DbType DatabaseType { get; set; }

        private void Validated()
        {
            if (string.IsNullOrEmpty(Server))
                throw new Exception("Server name not set");

            if (string.IsNullOrEmpty(UserId))
                throw new Exception("User not set");

            if (string.IsNullOrEmpty(Database))
                throw new Exception("Database not set");
            if (string.IsNullOrEmpty(Password))
                throw new Exception("Password not set");
        }

        public string Server { get; private set; }
        public string Database { get; private set; }
        public string UserId { get; private set; }
        public string Password { get; private set; }
        public int Port { get; set; }
        public void SetDatabase(string databaseName)
        {
            this.Database = databaseName;
            Validated();
        }
        public override string ToString()
        {
            var connString = string.Empty;
            switch (DatabaseType)
            {
                case DbType.Postgress:
                    connString = $"host={Server}; database={Database}; user id={UserId}; password={Password}";
                    if (Port != 0)
                        return connString + $" port={Port};";
                    else
                        return connString;
                case DbType.SqlServer:
                    connString = $"server={Server}; database={Database}; user id={UserId}; password={Password}";
                    if (Port != 0)
                        return connString + $" port={Port};";
                    else
                        return connString;
                case DbType.SAPHana:
                    connString = $"server={Server}; database={Database}; user id={UserId}; password={Password}";
                    if (Port != 0)
                        return connString + $" port={Port};";
                    else
                        return connString;
                default:
                    connString = $"server={Server}; database={Database}; user id={UserId}; password={Password}";
                    if (Port != 0)
                        return connString + $" port={Port};";
                    else
                        return connString;

            }

        }
    }

    public enum DbType
    {
        SqlServer,
        Postgress,
        SAPHana
    }
}
