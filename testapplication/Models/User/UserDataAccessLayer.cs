using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using testapplication.DB;
using testapplication.Models.Tables_Model;

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
                user.Id = Id;
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

        public static RoleItem getRole(string userNationalCode)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = "select tRole.Id , tRole.Role from tUser " +
            "join tUserRole on tUser.Id = tUserRole.User_Id "+
            "join tRole on tUserRole.Role_Id = tRole.Id "+
            "where tUser.NationalCode = @nationalcode ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nationalcode", userNationalCode);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int Id = Convert.ToInt32(dr["Id"]);
                string title = dr["Role"].ToString();
                RoleItem role = new RoleItem(Id, title);
                return role;
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

            string query = $"select * from {table} where IsDeleted = 0";

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

        public static List<ItemTable> getInfo(string uid)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select * from t{uid} where Id > 0 and IsDeleted = 0";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<ItemTable> itemTables = new List<ItemTable>();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["Id"]);
                string title = dr["Title"].ToString();
                int count = getUseCount(id);
                ItemTable item = new ItemTable(id, title);
                item.SetUseCount(count);
                itemTables.Add(item);
            }

            return itemTables;
        }

        public static List<RelativeItem> GetRelativeItems(string uid)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select * from t{uid} where Id > 0 and IsDeleted = 0";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<RelativeItem> items = new List<RelativeItem>();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["Id"]);
                string title = dr["Title"].ToString();
                int count = getUseCount(id);
                RelativeItem item = new RelativeItem(id, title);
                item.TypeTitle = "FamilyType";
                item.SetUseCount(count);
                items.Add(item);

            }

            return items;
        }

        public static List<ReligionItem> GetReligionItems(string uid)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
            string query = $"select * from t{uid} where Id > 0 and IsDeleted = 0";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<ReligionItem> items = new List<ReligionItem>();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["Id"]);
                string title = dr["Title"].ToString();
                int count = getUseCount(id);
                ReligionItem item = new ReligionItem(id, title);
                item.SetUseCount(count);
                items.Add(item);
            }

            return items;
        }

        public static List<DegreeEducationItem> GetDegreeEducationItems(string uid)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
            string query = $"select * from t{uid} where Id > 0 and IsDeleted = 0";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<DegreeEducationItem> items = new List<DegreeEducationItem>();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["Id"]);
                string title = dr["Title"].ToString();
                int count = getUseCount(id);
                DegreeEducationItem item = new DegreeEducationItem(id, title);
                item.SetUseCount(count);
                items.Add(item);
            }

            return items;
        }

        public static List<UsersItem> GetUsersItems(string uid)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
            string query = "select tUser.Id, tUser.FirstName+tUser.LastName as FullName ,tUser.FatherName , tUser.NationalCode , tUser.IsDeleted, tRole.Role " +
                           "from  tuser  left join tUserRole on tUser.Id = tUserRole.User_Id " +
                           "left join tRole on tRole.Id = tUserRole.Role_Id " +
                           "where (tRole.Role != 'admin' or tRole.Role is null) and tUser.password is not null ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<UsersItem> items = new List<UsersItem>();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["Id"]);
                string title = dr["FullName"].ToString();
                string FatherName = dr["FatherName"].ToString();
                string NationalCode = dr["NationalCode"].ToString();
                string Role = dr["Role"].ToString();
                bool IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
                int count = getFamilyCount(id);
                UsersItem item = new UsersItem(id, title,NationalCode,FatherName,Role,count,IsDeleted);
                items.Add(item);
            }

            return items;
        }

        public static List<MilitaryStatusItem> GetMilitaryStatusItems(string uid)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
            string query = $"select * from t{uid} where Id > 0 and IsDeleted = 0";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<MilitaryStatusItem> items = new List<MilitaryStatusItem>();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["Id"]);
                string title = dr["Title"].ToString();
                int count = getUseCount(id);
                MilitaryStatusItem item = new MilitaryStatusItem(id, title);
                item.SetUseCount(count);
                items.Add(item);
            }

            return items;
        }

        //public static ProvinceItem GetStateItems(int id)
        //{
        //    using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());
        //    string query = "select p.Id pid , p.Title ptitle , c.Id cid , c.Title ctitle from tProvince p" +
        //    "join tCity c on c.Province_id = p.Id"+
        //    $"where p.id = {id} and p.IsDeleted = 0 and c.IsDeleted = 0";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        // //   List<ProvinceItem> items = new List<ProvinceItem>();
        //    ProvinceItem provinceItem = new ProvinceItem();
        //    bool f = true;
        //    while (dr.Read())
        //    {
        //        int pid = Convert.ToInt32(dr["pid"]);
        //        string ptitle = dr["ptitle"].ToString();
        //        int cid = Convert.ToInt32(dr["cid"]);
        //        string ctitle = dr["ctitle"].ToString();
        //        // int count = getUseCount(id);
        //        if (f)
        //        {
        //            provinceItem = new ProvinceItem(id, ptitle);
        //            f = false;
        //        }

        //        CityItem cityItem = new CityItem(cid, ctitle);
        //        provinceItem.CityItems.Add(cityItem);
        //       // provinceItem.SetUseCount(count);
        //       // items.Add(provinceItem);
        //    }

        //    return provinceItem;
        //}
        public static List<CityItem> GetStateItems(int id)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass._connectionString);
            string query = "select c.Id cid , c.Title ctitle from tCity c " +
                           $"where c.Province_id = {id} and c.IsDeleted = 0";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //   List<ProvinceItem> items = new List<ProvinceItem>();
            List<CityItem> cityItems = new List<CityItem>();
            while (dr.Read())
            {
                int cid = Convert.ToInt32(dr["cid"]);
                string ctitle = dr["ctitle"].ToString();
                int count = getUseCount(cid);


                CityItem cityItem = new CityItem(cid, ctitle);
                cityItems.Add(cityItem);
                // provinceItem.SetUseCount(count);
                // items.Add(provinceItem);
            }

            return cityItems;
        }

        public static int getUseCount(int id)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select COUNT(*) AS Number from tUserType where TypeId = {id}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
          //  List<ItemTable> itemTables = new List<ItemTable>();
            int count = 0;
            while (dr.Read())
            {
                count = Convert.ToInt32(dr["Number"]);
            }

            return count;
        }

        public static int getFamilyCount(int id)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select COUNT(*) AS Number from tUserType where ParentId= {id}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
           // List<ItemTable> itemTables = new List<ItemTable>();
            int count = 0;
            while (dr.Read())
            {
                count = Convert.ToInt32(dr["Number"]);
            }

            return count;
        }


        public static List<string> getItemTitle(string uid)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select Title from t{uid} where Id > 0 ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> titleList = new List<string>();
            while (dr.Read())
            {
                string title = dr["Title"].ToString();
                titleList.Add(title);
            }

            return titleList;
        }

        public static Item getItem(string uid, int id)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"select * from t{uid} where Id = {id} ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            // List<ItemTable> itemTables = new List<ItemTable>();
            Item item = new Item();
            while (dr.Read())
            {
                //  int id = Convert.ToInt32(dr["Id"]);
                string title = dr["Title"].ToString();
                item.Title = title;
                item.TypeTitle = uid;
                item.Id = id;
                //  itemTables.Add(item);
            }

            return item;
        }


        public static void InsertItem(Item item)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass._connectionString);

            string query = $"Insert Into t{item.TypeTitle}(Title) values('{item.Title}')";
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

        public static void UpdateItem(Item item)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"Update t{item.TypeTitle} set Title = '{item.Title}' where Id = {item.Id}";


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


        public static void UpdateIsDeletedItem(int id,string title, bool IsDeleted)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = $"Update t{title} set IsDeleted = '{IsDeleted}' where Id = {id}";


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