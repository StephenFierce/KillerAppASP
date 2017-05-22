using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KillerAppASP.Interfaces
{
    public interface IDatabaseConnector
    {
        IDbCommand CreateCommand();

        void ExecuteNonQuery(IDbCommand command);

        IDataReader ExecuteReader(IDbCommand command);
    }
}
