using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WebAnuciaAqui.Infra.BancoDeDados
{
    public interface IDatabaseCreator
    {
        void Createdatabase();
        bool ExistsDatabase();
        IDbConnection GetConnection(ServerInformation serverInf);
        IDbConnection GetConnection();
        string GetSqlToReturnId(string fieldKey);
    }
}
