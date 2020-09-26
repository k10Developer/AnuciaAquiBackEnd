using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WebAnuciaAqui.Infra.BancoDeDados
{
    public class DatabaseFactory : IDatabaseFactory
    {
        public ServerInformation ServerInformation { get; set; }

        public IDbConnection DbConnection
        {
            get
            {
                return GetCreator().GetConnection();
            }
        }

        public DatabaseFactory(ServerInformation serverinfo)
        {
            ServerInformation = serverinfo;
        }

        public IDatabaseCreator GetCreator()
        {
            switch (ServerInformation.DatabaseType)
            {
                //case DbType.SqlServer:
                //    return new DatabaseCreators.SqlServerDatabaseCreator(ServerInformation);
                case DbType.Postgress:
                    return new PostgreSQLCreator(ServerInformation);
                case DbType.SAPHana:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException(); ;
            }
        }
    }
}
