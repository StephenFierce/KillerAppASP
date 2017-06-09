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

        public User GetItem(int ID)
        {
            User user = new User();
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLConnector.ConnectionString))
                {
                    string query = "SELECT * FROM [User] WHERE ID = @ID;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("ID", ID);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
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
            catch (Exception ex)
            {
                // write log
                //WriteLog(Name mthode, ex.Message);
            }
            return user;
        }

        public List<User> Read()
        {
            List<User> users = new List<User>();
            // User user = null;
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLConnector.ConnectionString))
                {
                    string query = "SELECT * FROM [User];";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Clear();
                        //cmd.Parameters.AddWithValue("@id", someparm;)
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    User user = new User();

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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // write log
                //WriteLog(Name mthode, ex.Message);
            }
            return users;

        }

        public void Update(User item)
        {
            User user = new User();
            user = item;
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLConnector.ConnectionString))
                {
                    string query = "UPDATE [User] SET [Username] = @Username, [Password] = @Password, [DateofBirth] = @Dateofbirth, [Email] = @Email,[DisplayName] = @Displayname,[Bio] = @Bio,[OfflineBanner] = @Offlinebanner,[ForbiddenWords] = @Forbiddenwords  WHERE ID = @ID; ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("ID", user.ID);
                        cmd.Parameters.AddWithValue("Username", user.Username);
                        cmd.Parameters.AddWithValue("Password", user.Password);
                        cmd.Parameters.AddWithValue("Dateofbirth", user.DateofBirth);
                        cmd.Parameters.AddWithValue("Email", user.Email);
                        cmd.Parameters.AddWithValue("Displayname", user.DisplayName);
                        cmd.Parameters.AddWithValue("Bio", user.Bio);
                        cmd.Parameters.AddWithValue("Offlinebanner", user.OfflineBanner);
                        cmd.Parameters.AddWithValue("Forbiddenwords", user.ForbiddenWords);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}