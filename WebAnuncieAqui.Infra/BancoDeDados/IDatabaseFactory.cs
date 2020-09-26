using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WebAnuciaAqui.Infra.BancoDeDados
{
    public interface IDatabaseFactory
    {
        IDatabaseCreator GetCreator();
        ServerInformation ServerInformation { get; set; }
        IDbConnection DbConnection { get; }
    }
}
