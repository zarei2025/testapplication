using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace testapplication.Models
{
    public class BaseQuery
    {
        private static string _connectionString =
            "Data Source=.;Initial Catalog=TestDb;User ID=sa;Password=12345678";

        static SqlConnection con = new(_connectionString);

        // Get All Country

        public DataSet Get_Province()
        {
            SqlCommand com = new SqlCommand("Select * from tProvince", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        //Get all City
        public DataSet Get_City(int province_id)
        {
            SqlCommand com = new SqlCommand("Select * from tCity where Province_id=@provinceid", con);
            com.Parameters.AddWithValue("@provinceid", province_id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}