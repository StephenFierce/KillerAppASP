using KillerAppASP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace KillerAppASP.Connector
{
    public class MSSQLConnector : IDatabaseConnector
    {
        public SqlConnection _connection;
        public static string ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionIris"].ConnectionString;
        public static MSSQLConnector Instance
        {     
            get
            {
                return _instance;
            }
        }

        private static readonly MSSQLConnector _instance;

        static MSSQLConnector()
        {
            _instance = new MSSQLConnector();
        }
        private MSSQLConnector()
        {
            _connection = new SqlConnection(ConnectionString);
        }

        public IDbCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }

        public void ExecuteNonQuery(IDbCommand command)
        {
            Open();

            using (command)
                command.ExecuteNonQuery();

            Close();
        }

        public IDataReader ExecuteReader(IDbCommand command)
        {
            Open();

            using (command)
                return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        private void Open()
        {
            _connection.Open();
        }

        private void Close()
        {
            _connection.Close();
        }

    }
}