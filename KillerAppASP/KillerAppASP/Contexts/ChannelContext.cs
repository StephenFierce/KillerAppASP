using KillerAppASP.Connector;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KillerAppASP.Contexts
{
    public class ChannelContext : IContext<Channel>
    {
        private readonly IDatabaseConnector _connector;

        public ChannelContext(IDatabaseConnector connector)
        {
            _connector = connector;
        }

        public void Create(Channel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Channel item)
        {
            throw new NotImplementedException();
        }

        public Channel GetItem(int ID)
        {
            Channel channel = new Channel();
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLConnector.ConnectionString))
                {
                    string query = "SELECT * FROM [Channel] WHERE ID = @ID;";
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
                                    channel.ID = reader.GetInt32(0);
                                    channel.Banner = reader.GetString(2);
                                    channel.Name = reader.GetString(1);
                                    channel.ProfilePicture = reader.GetString(3);
                                    channel.Views = reader.GetInt32(4);
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
            return channel;
        }

        public List<Channel> Read()
        {
            List<Channel> Channels = new List<Channel>();
            // Channel Channel = null;
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLConnector.ConnectionString))
                {
                    string query = "SELECT * FROM [Channel];";
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
                                    Channel channel = new Channel();

                                    channel.ID = reader.GetInt32(0);
                                    channel.Banner = reader.GetString(2);
                                    channel.Name = reader.GetString(1);
                                    channel.ProfilePicture = reader.GetString(3);
                                    channel.Views = reader.GetInt32(4);
                                    

                                    Channels.Add(channel);
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
            return Channels;

        }

        public void Update(Channel item)
        {
            Channel channel = new Channel();
            channel = item;
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLConnector.ConnectionString))
                {
                    string query = "UPDATE [Channel] SET [Name] = @Name, [Banner] = @Banner, [ProfilePic] = @ProfilePicture WHERE ID = @ID; ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("ID", channel.ID);
                        cmd.Parameters.AddWithValue("Name", channel.Name);
                        cmd.Parameters.AddWithValue("Banner", channel.Banner);
                        cmd.Parameters.AddWithValue("ProfilePicture", channel.ProfilePicture);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // write log
                //WriteLog(Name mthode, ex.Message);
            }
        }
    }
}