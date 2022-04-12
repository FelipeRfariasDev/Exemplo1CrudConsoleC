using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Aula1.Data
{
    public class DefaultConnection
    {
        SqlConnection con;
        string connectionString = "";
        public DefaultConnection(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BlogConnectionString");
            con = new SqlConnection(connectionString);
            OpenConnection();
        }

        public void OpenConnection() 
        {
            con.Open();
        }

        public void CloseConnection() 
        {
            con.Close();
        }

        public void ExecuteCommand(string query) 
        {
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
