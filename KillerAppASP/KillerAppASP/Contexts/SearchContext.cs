using KillerAppASP.Connector;
using KillerAppASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KillerAppASP.Contexts
{
    public class SearchContext
    {
        public List<Search> Search(string SearchQuery)
        {
            List<Search> results = new List<Search>();
            // User user = null;
            try
            {
                using (SqlConnection con = new SqlConnection(MSSQLConnector.ConnectionString))
                {
                    string query = "EXEC dbo.spSearch @SearchQuery";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("SearchQuery", SearchQuery);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Search s = new Search(reader.GetString(0), reader.GetString(1), reader.GetString(2).ToString());
                                    results.Add(s);
                                }
                                reader.NextResult();
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
            return results;

        }
    }
}