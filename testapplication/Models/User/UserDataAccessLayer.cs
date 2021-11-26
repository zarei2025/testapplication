using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using testapplication.DB;

namespace testapplication.Models
{
    public static class UserDataAccessLayer
    {
        //static ConnectionDbclass cs = new ConnectionDbclass();

        public static List<User> GetAllUser()
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = "select * from tUser";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<User> users = new List<User>();

            while (dr.Read())
            {
                long Id = Convert.ToInt32(dr["Id"]);
                String FirstName = dr["FirstName"].ToString();
                String LastName = dr["LastName"].ToString();
                String Password = dr["Password"].ToString();
                String NationalCode = dr["NationalCode"].ToString();
                User user = new User(NationalCode, Password, FirstName, LastName);
                Id = Id;
                users.Add(user);
            }

            return users;
        }

        public static void AddUser(User user)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
            string query =
                $"Insert into tUser " +
                $"Values('{user.NationalCode}', null , '{user.FirstName}', '{user.LastName}' , '{user.Status}' , '1' ," +
                $" '{user.FatherName}' , '{user.PhoneNumber}' , '{user.HomePhone}' , '{user.Gender}' , '{user.Province}' , '{user.City}' , '{user.Address}' ," +
                $" '{user.PostalCode}' , '{user.Email}' , '{user.BirthDate}' , '{user.BirthPlace}' , '{user.DegreeEducation}' , '{user.Job}' , '{user.WorkPlace}' ," +
                $" '{user.WorkPostalCode}' , '{user.WorkPhone}' , '{user.Nationality}' , '{user.Religion}' , '{user.Sect}' , '{user.MilitaryStatus}', '0')";
            con.Open();
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

        public static void AddFamilyUser(User user)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
            string query =
                $"Insert into tUser " +
                $"Values('{user.NationalCode}', null , '{user.FirstName}', '{user.LastName}' , '{user.Status}' , '0' ," +
                $" '{user.FatherName}' , '{user.PhoneNumber}' , '{user.HomePhone}' , '{user.Gender}' , '{user.Province}' , '{user.City}' , '{user.Address}' ," +
                $" '{user.PostalCode}' , '{user.Email}' , '{user.BirthDate}' , '{user.BirthPlace}' , '{user.DegreeEducation}' , '{user.Job}' , '{user.WorkPlace}' ," +
                $" '{user.WorkPostalCode}' , '{user.WorkPhone}' , '{user.Nationality}' , '{user.Religion}' , '{user.Sect}' , '{user.MilitaryStatus}', '0')";
            con.Open();
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

        public static void UpdateUser(User user)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query =
                $"Update tUser  SET FirstName = '{user.FirstName}', LastName = '{user.LastName}', NationalCode = '{user.NationalCode}' ," +
                $" FatherName = '{user.FatherName}' , PhoneNumber='{user.PhoneNumber}' , HomePhone='{user.HomePhone}' , Gender='{user.Gender}' ," +
                $" Province_id= '{user.Province}' , City_id = '{user.City}' , Address='{user.Address}' ," +
                $" PostalCode = '{user.PostalCode}' , Email = '{user.Email}' , BirthDate = '{user.BirthDate}' , BirthPlace = '{user.BirthPlace}' ," +
                $" DegreeEducation_id = '{user.DegreeEducation}' , Job = '{user.Job}' , WorkPlace = '{user.WorkPlace}' , WorkPostalCode = '{user.WorkPostalCode}' ," +
                $" WorkPhone = '{user.WorkPhone}' , Nationality = '{user.Nationality}' , Religion_id = '{user.Religion}' ," +
                $" Sect = '{user.Sect}' , MilitaryStatus_id = '{user.MilitaryStatus}' " +
                $" where id = {user.Id}";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                con.Close();
            }
        }

        public static long GetNextUserId()
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = "select IDENT_CURRENT('tUser') as next_id";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<User> users = new List<User>();
            long Id = 0;
            while (dr.Read())
            {
                Id = Convert.ToInt32(dr["next_id"]);
            }

            return Id;
        }

        public static long GetUserIdBy(string nationalcode)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select Id from tUser where NationalCode = '{nationalcode}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            return dr.Read() ? Convert.ToInt64(dr["Id"]) : -1;
        }

        public static User GetUserBy(long id)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select * from tUser where Id = '{id}'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                long Id = Convert.ToInt64(dr["Id"]);
                string FirstName = dr["FirstName"].ToString();
                string LastName = dr["LastName"].ToString();
                string NationalCode = dr["NationalCode"].ToString();
                string Password = dr["password"].ToString();
                string FatherName = dr["FatherName"].ToString();
                string PhoneNumber = dr["PhoneNumber"].ToString();
                string HomePhone = dr["HomePhone"].ToString();
                char Gender = Convert.ToChar(dr["Gender"]);
                int Province = Convert.ToInt32(dr["Province_id"]);
                int City = Convert.ToInt32(dr["City_id"]);
                string Address = dr["Address"].ToString();
                string PostalCode = dr["PostalCode"].ToString();
                string Email = dr["Email"].ToString();
                DateTime BirthDate = Convert.ToDateTime(dr["BirthDate"]);
                string BirthPlace = dr["BirthPlace"].ToString();
                //    string Item = dr["Item"].ToString();
                string Job = dr["Job"].ToString();
                string WorkPlace = dr["WorkPlace"].ToString();
                string WorkPostalCode = dr["WorkPostalCode"].ToString();
                string WorkPhone = dr["WorkPhone"].ToString();
                string Nationality = dr["Nationality"].ToString();
                int Religion = Convert.ToInt32(dr["Religion_id"]);
                string Sect = dr["Sect"].ToString();
                int MilitaryStatus = Convert.ToInt32(dr["MilitaryStatus_id"]);
                int degreeEducation = Convert.ToInt32(dr["DegreeEducation_id"]);
                bool Status = Convert.ToBoolean(dr["Status"]);
                bool MainUser = Convert.ToBoolean(dr["MainUser"]);
                User user = new User(NationalCode, FirstName, LastName, Status, MainUser, FatherName,
                    PhoneNumber, HomePhone, Gender, Province, City, Address, PostalCode, Email, BirthDate, BirthPlace,
                    degreeEducation, Job, WorkPlace, WorkPostalCode, WorkPhone, Nationality, Religion, Sect,
                    MilitaryStatus);
                return user;
            }

            return null;
        }

        public static User GetUserBy(string nationalcode, string password)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = "select * from tUser where NationalCode = @nationalcode and password = @password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nationalcode", nationalcode);
            cmd.Parameters.AddWithValue("@password", ComputeSha256Hash(password));
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                long Id = Convert.ToInt32(dr["Id"]);
                String FirstName = dr["FirstName"].ToString();
                String LastName = dr["LastName"].ToString();
                String Password = dr["Password"].ToString();
                String NationalCode = dr["NationalCode"].ToString();
                User user = new User(NationalCode, Password, FirstName, LastName);
                user.Id = Id;
                return user;
            }

            return null;
        }
        /*  public static User GetUserBy(string nationalcode, string password)
          {
             // using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
              string query = $"select * from tUser where NationalCode = '{nationalcode}' and password = '{ComputeSha256Hash(password)}'";
              SqlCommand cmd = ConnectionDbclass.Connecting(query);

             // ConnectionDbclass connectionDbclass = new ConnectionDbclass(cmd);

             // SqlCommand cmd = new SqlCommand(query, con);
            //  cmd.Parameters.AddWithValue("@nationalcode", nationalcode);
            //  cmd.Parameters.AddWithValue("@password", ComputeSha256Hash(password));
              //con.Open();
            //  SqlDataReader dr = cmd.ExecuteReader();
             SqlDataReader dr = ConnectionDbclass.drcreate();
              User user = null;
              while (dr.Read())
              {
                  long Id = Convert.ToInt32(dr["Id"]);
                  String FirstName = dr["FirstName"].ToString();
                  String LastName = dr["LastName"].ToString();
                  String Password = dr["Password"].ToString();
                  String NationalCode = dr["NationalCode"].ToString();
                  user = new User(NationalCode, Password, FirstName, LastName);
                  user.Id = Id;
              }

              dr.Close();
              cmd.Dispose();
              if (user!=null)
              {
                  return user;
              }
              return null;
          }
        */


        public static List<UserType> GetFamily(long id)
        {
            string query =
                "select tu1.Id as pid,tu1.FirstName as pfn, tu1.LastName as pln," +
                " tu1.NationalCode pnc , tu2.Id as id, tu2.FirstName as fn, tu2.LastName as ln," +
                " tu2.NationalCode as nc, tft.Title as tt, tu2.IsDeleted" +
                " from tUser tu1" +
                " join tUserType tut on tu1.Id = tut.ParentId " +
                " join tUser tu2 on tu2.Id = tut.UserId" +
                " join tFamilyType tft on tut.TypeId = tft.Id " +
                $"where tu1.Id  = {id} and tu2.IsDeleted = 0";


            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());


            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<UserType> userTypes = new List<UserType>();

            while (dr.Read())
            {
                long ParentId = Convert.ToInt64(dr["pid"]);
                string ParentFirstName = dr["pfn"].ToString();
                string ParentLastName = dr["pln"].ToString();
                string ParentNationalCode = dr["pnc"].ToString();
                long Id = Convert.ToInt64(dr["id"]);
                string FirstName = dr["fn"].ToString();
                string LastName = dr["ln"].ToString();
                string NationalCode = dr["nc"].ToString();
                string TypeTitle = dr["tt"].ToString();
                User parentUser = new User(ParentId, ParentNationalCode, ParentFirstName, ParentLastName);
                User user = new User(Id, NationalCode, FirstName, LastName);
                UserType userType = new UserType(parentUser, user, TypeTitle);


                userTypes.Add(userType);
            }


            //ListUser listUser = new ListUser(userTypes);
            return userTypes;
        }

        public static void DeleteUser(long id)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
            string query =
                $"Update tUser  SET IsDeleted = 1 where id = {id}";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                con.Close();
            }
        }


        public static List<Item> GetItem(string table)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select * from {table}";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Item> items = new List<Item>();
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["Id"]);
                string title = dr["Title"].ToString();
                Item item;

                try
                {
                    int parentId = Convert.ToInt32(dr["Parent_Id"]);
                    item = new Item(id, title, parentId);
                }
                catch (Exception)
                {
                    item = new Item(id, title);
                }
                //int parentId = 

                // return dr.Read() ? Convert.ToInt64(dr["Id"]) : -1;
                //   int id = Convert.ToInt32(dr["Id"]);


                // Item item = new Item(id, title);

                items.Add(item);
            }


            return items;
        }


        public static void Password(User user)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
            string query =
                $"Update tUser  SET Password = '{ComputeSha256Hash(user.Password)}' where id = (select max(id) from tUser) ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                con.Close();
            }
        }

        public static string GetUserPassBy(long id)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select Password from tUser where Id = {id} ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string Password = dr["Password"].ToString();
                return Password;
            }

            return null;
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

        public static List<string> getInfo(string uid)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select * from t{uid}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> degree = new List<string>();

            while (dr.Read())
            {
                String title = dr["Title"].ToString();
                degree.Add(title);
            }

            return degree;
        }

       
        public static void updateRows(List<string> titles, string titleId)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string s = null;
            foreach (var title in titles)
            {
                s += $"('{title}'),";
            }

            string query =
                    $"Insert Into t{titleId}(Title) values {s}";
            query = query.Remove(query.Length - 1);
            

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }