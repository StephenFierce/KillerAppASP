using KillerAppASP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace KillerAppASP.Connector
{
    public class MSSQLConnector : IDatabaseConnector
    {
        public int NonQuery(SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public SqlDataReader Query(SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        private static string ConnectionString = @"bla bla string";
    }
}