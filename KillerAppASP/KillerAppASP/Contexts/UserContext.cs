using KillerAppASP.Connector;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KillerAppASP.Contexts
{
    public class UserContext : IContext<User>
    {
        private readonly IDatabaseConnector _connector;

        public UserContext(IDatabaseConnector connector)
        {
            _connector = connector;
        }

        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public List<User> Read()
        {
            List<User> users = new List<User>();
            User user = null;
            SqlConnection con = new SqlConnection(MSSQLConnector.ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM [User];", con);
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                
                while (reader.Read())
                {
                    user = new User();
                    user.ID = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.DateofBirth = reader.GetDateTime(3);
                    user.Partner = Convert.ToBoolean(reader.GetInt32(5));
                    user.DisplayName = reader.GetString(6);
                    user.Bio = reader.GetString(7);
                    user.OfflineBanner = reader.GetString(8);
                    user.ForbiddenWords = reader.GetString(9);
                    users.Add(user);
                }
                
            }
            con.Close();
            return users;
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}