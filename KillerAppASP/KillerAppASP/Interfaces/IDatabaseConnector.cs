using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KillerAppASP.Interfaces
{
    public interface IDatabaseConnector
    {
        int NonQuery(SqlCommand cmd);
        SqlDataReader Query(SqlCommand cmd);

    }
}
