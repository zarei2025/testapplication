using System.Data.SqlClient;
using System.Data;

namespace testapplication.DB
{
    public  class ConnectionDbclass
    {
        public static string _connectionString =
            "Data Source=.;Initial Catalog=TestDb;User ID=sa;Password=12345678";

        public static  SqlConnection con = new SqlConnection(_connectionString);
        public static SqlCommand cmd;
        public static SqlDataReader dr;

        

        public static SqlCommand Connecting(string query)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd = new SqlCommand(query, con);
            using (dr = cmd.ExecuteReader())
            {
                return cmd;
            }
            //try
            //{

            //    dr = cmd.ExecuteReader();
            //}
            //catch (Exception e)
            //{
            // dr.CloseAsync();
            // dr = cmd.ExecuteReader();
            //}

        //    dr = cmd.ExecuteReader();
            
        }

        public static SqlDataReader drcreate()
        {
            //if (dr.IsClosed)
            //{

            //    dr = cmd.ExecuteReader();

            //}
            //return dr;

            using (dr = cmd.ExecuteReader())
            {
                return dr;
            }
        }

        //public static SqlDataReader drcreate(SqlCommand cmd1)
        //{
            
        //    if (dr.IsClosed)
        //    {
        //        dr = cmd1.ExecuteReader();

        //    }
        //    return dr;
        //}
        public static void drclose()
        {
            dr.Close();
        }


        public static void ConClose()
        {
            con.Close();
        }

        public  static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}