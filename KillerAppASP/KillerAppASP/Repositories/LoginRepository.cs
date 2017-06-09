using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using KillerAppASP.Connector;
using KillerAppASP.Exceptions;

namespace KillerAppASP.Repositories
{
    public class LoginRepository
    {
        private readonly IDatabaseConnector _connector;
        public LoginRepository(IDatabaseConnector connector)
        {
            _connector = connector;
        }
        
        public User Login(string name,string password)
        {
            User user = new User();
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLConnector.ConnectionString))
                {
                    string query = "SELECT TOP 1 * FROM [User] AS a WHERE (a.[Username] = @username OR a.[Email] = @email) AND a.[Password] = @password;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("email", name);
                        cmd.Parameters.AddWithValue("username", name);
                        cmd.Parameters.AddWithValue("password", password);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                throw new LoginException("Incorrect account credentials!");
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    user.ID = reader.GetInt32(0);
                                    user.Username = reader.GetString(1);
                                    user.DateofBirth = reader.GetDateTime(3);
                                    user.Partner = Convert.ToBoolean(reader.GetInt32(5));
                                    user.DisplayName = reader.GetString(6);
                                    user.Bio = reader.GetString(7);
                                    user.OfflineBanner = reader.GetString(8);
                                    user.ForbiddenWords = reader.GetString(9);
                                }
                            }
                        }
                    }
                }
            }
            catch (LoginException)
            {

            }
            return user;
        }
    }
}