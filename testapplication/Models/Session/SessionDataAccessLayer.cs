using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using testapplication.DB;

namespace testapplication.Models.Session
{
    public static class SessionDataAccessLayer
    {
      //  static ConnectionDbclass ConnectionDbclass = new ConnectionDbclass();

        public static SortedDictionary<long, long> SelectAll()
        {
            string query;
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
            con.Open();

            query = "SELECT Id, UserId From tSession";

            SortedDictionary<long, long> map = new SortedDictionary<long, long>();

            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                long Id = Convert.ToInt32(dr["Id"]);
                long UserId = Convert.ToInt32(dr["UserId"]);

     
                map.Add(Id, UserId);
            }

            return map;

        }

        public static void AddSession(Session session)
        {
            string query;
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
            con.Open();
            long session_id = GetSessionIdByUser(session.UserId);

            if(session.UserId == 0)
            {




              //  SortedDictionary<long, long> map =  SelectAll();

               

               // Console.WriteLine(u);


           //    map.Keys[];







            }

            if (session_id == -1)
            {
                query = "Insert into tSession (UserId,CheckString,CreateDate, UpdateDate) " +
                         $"Values({session.UserId},'{ComputeSha256Hash(session.CheckString)}', GETDATE(), GETDATE())";
            }
            else
            {
                query = "UPDATE tSession" +
                         $" SET CheckString = '{ComputeSha256Hash(session.CheckString)}', CreateDate = GETDATE() , UpdateDate = GETDATE()" +
                         $" WHERE Id ={session_id};";
            }
            
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }

            finally
            {


                long id = session.Id;
                con.Close();
            }
        }

        public static void UpdateSession(string Checkstring)
        {
            string query;
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
            con.Open();
  
                query = "UPDATE tSession" +
                        $" SET UpdateDate = GETDATE()" +
                        $" WHERE CheckString = '{Checkstring}';";

                SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }

            finally
            {
                con.Close();
            }

        }

        public static long GetSessionIdByUser(long Id)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string quarry = $"select Id from tSession where UserId = '{Id}'";
            SqlCommand cmd = new SqlCommand(quarry, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            return dr.Read() ? Convert.ToInt64(dr["Id"]) : -1;
        }
        public static string GetSessionCheckstring(string CheckString , int timeSecond)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string quarry = $"select CheckString from tSession where CheckString = '{CheckString}' AND DATEDIFF(SECOND, UpdateDate, GETDATE())< {timeSecond}";
            SqlCommand cmd = new SqlCommand(quarry, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            return dr.Read() ? dr["CheckString"].ToString() : null;
        }

        public static string GetDateAndTime(string CheckString)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select UpdateDate from tSession where CheckString = '{CheckString}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            return dr.Read() ? dr["CheckString"].ToString() : null;
        }



        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

       
    }
}