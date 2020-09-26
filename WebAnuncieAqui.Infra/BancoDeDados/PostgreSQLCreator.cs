using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WebAnuciaAqui.Infra.BancoDeDados
{
    public class PostgreSQLCreator : IDatabaseCreator
    {
        private ServerInformation _serverInf;

        public PostgreSQLCreator(ServerInformation serverInf)
        {
            _serverInf = serverInf;
        }
        public void Createdatabase()
        {
            if (ExistsDatabase())
                return;
            var newServerInfoWithMasterDatabase = new ServerInformation(DbType.Postgress, _serverInf.Server, "postgres", _serverInf.UserId, _serverInf.Password);
            using (var conn = new Npgsql.NpgsqlConnection(newServerInfoWithMasterDatabase.ToString()))
            {
                conn.Open();

                var command = conn.CreateCommand();
                command.CommandText = $"CREATE DATABASE \"{_serverInf.Database}\" ";

                command.ExecuteNonQuery();

                conn.Close();
            }
        }

        public bool ExistsDatabase()
        {
            var newServerInfoWithMasterDatabase = new ServerInformation(DbType.Postgress, _serverInf.Server, "postgres", _serverInf.UserId, _serverInf.Password);
            using (var conn = GetConnection(newServerInfoWithMasterDatabase))
            {
                conn.Open();

                var command = conn.CreateCommand();
                command.CommandText = $"select * from pg_database where datname = '{_serverInf.Database}'";

                var reader = command.ExecuteReader();
                var data = new DataTable();
                data.Load(reader);
                return data.Rows.Count > 0;
            }
        }

        public IDbConnection GetConnection(ServerInformation serverInf)
        {
            return new Npgsql.NpgsqlConnection(serverInf.ToString());

        }

        public IDbConnection GetConnection()
        {
            return new Npgsql.NpgsqlConnection(_serverInf.ToString());
        }

        public string GetSqlToReturnId(string field)
        {
            return $"RETURNING {field}";
        }       
    }
}
