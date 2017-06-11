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
    public class MessageContext : IContext<ChatMessage>
    {
        private IDatabaseConnector connector;

        public MessageContext(IDatabaseConnector connector)
        {
            this.connector = connector;
        }

        public void Create(ChatMessage item)
        {
            ChatMessage cm = item;
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLConnector.ConnectionString))
                {
                    string query = "INSERT INTO [dbo].[ChatMessage] ([Channel_ID], [Message], [User_ID], [Timestamp]) VALUES (@cid, @message, @uid, @timestamp)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("cid", cm.ChannelID);
                        cmd.Parameters.AddWithValue("message", cm.Message);
                        cmd.Parameters.AddWithValue("uid", cm.SentByUserID);
                        cmd.Parameters.AddWithValue("timestamp", cm.TimeStamp);
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

        public void Delete(ChatMessage item)
        {
            throw new NotImplementedException();
        }

        public ChatMessage GetItem(int ID)
        {
            throw new NotImplementedException();
        }

        public List<ChatMessage> GetItems(int channelID)
        {
            List<ChatMessage> cms = new List<ChatMessage>();
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLConnector.ConnectionString))
                {
                    string query = "SELECT * FROM [ChatMessage] WHERE [Channel_ID] = @cid;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("cid", channelID);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                                while (reader.Read())
                                {
                                    ChatMessage cm = new ChatMessage();
                                    cm.ChannelID = reader.GetInt32(1);
                                    cm.Message = reader.GetString(2);
                                    cm.SentByUserID = reader.GetInt32(3);
                                    cm.TimeStamp = reader.GetDateTime(4);
                                    cm.TimeStamp.ToShortTimeString();
                                    cms.Add(cm);
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
            return cms;
        }

        public List<ChatMessage> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(ChatMessage item)
        {
            throw new NotImplementedException();
        }
    }
}