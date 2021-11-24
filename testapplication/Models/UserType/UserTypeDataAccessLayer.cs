using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testapplication.DB;

namespace testapplication.Models
{
    public static class UserTypeDataAccessLayer
    {
     //   static ConnectionDbclass ConnectionDbclass = new ConnectionDbclass();

        public static IEnumerable<UserType> GetAllUserType()
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string quarry = "select * from tUserType";
            SqlCommand cmd = new SqlCommand(quarry, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<UserType> userTypes = new List<UserType>();

            while (dr.Read())
            {
                long Id = Convert.ToInt32(dr["Id"]);
                long UserId = Convert.ToInt32(dr["UserId"]);
                long ParentId = Convert.ToInt32(dr["ParentId"]);
                int TypeTitle = Convert.ToInt32(dr["TypeTitleId"]);
                DateTime CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                DateTime ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                UserType userType = new UserType(TypeTitle, CreateDate, ModifyDate);
                userType.Id = Id;
                userType.ParentId = ParentId;
                userType.User.Id = UserId;
                userTypes.Add(userType);
            }

            return userTypes;
        }


        public static UserType GetUserTypeBy(long id)
        {
            string query =
                "select tu2.Id as id, tu2.FirstName, tu2.LastName, tu2.NationalCode, tft.Title tt ," +
                "tu2.FatherName,tu2.BirthDate,tu2.BirthPlace,tu2.City_id,tu2.DegreeEducation_id,tu2.Email,tu2.Gender," +
                "tu2.HomePhone,tu2.Job,tu2.MilitaryStatus_id,tu2.Nationality,tu2.PhoneNumber,tu2.PostalCode,tu2.Province_id," +
                "tu2.Religion_id,tu2.Sect,tu2.WorkPhone,tu2.WorkPlace,tu2.WorkPostalCode , tu2.address , tut.TypeId as ti " +
                "from tUser tu1 " +
                "join tUserType tut on tu1.Id = tut.ParentId " +
                "join tUser tu2 on tu2.Id = tut.UserId " +
                "join tFamilyType tft on tut.TypeId = tft.Id " +
                $" where tu2.Id  = {id}";


            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());


            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            UserType userType;

            if (dr.Read())
            {
                long Id = Convert.ToInt64(dr["Id"]);
                string FirstName = dr["FirstName"].ToString();
                string LastName = dr["LastName"].ToString();
                string NationalCode = dr["NationalCode"].ToString();
                //string Password = dr["password"].ToString();
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
                //bool Status = Convert.ToBoolean(dr["Status"]);
                //bool MainUser = Convert.ToBoolean(dr["MainUser"]);
                string TypeTitle = dr["tt"].ToString();
                long type_id = Convert.ToInt64(dr["ti"]);


                User user = new User(NationalCode, FirstName, LastName, true, false, FatherName,
                    PhoneNumber, HomePhone, Gender, Province, City, Address, PostalCode, Email, BirthDate, BirthPlace,
                    degreeEducation, Job, WorkPlace, WorkPostalCode, WorkPhone, Nationality, Religion, Sect,
                    MilitaryStatus);

                userType = new UserType(null, user, TypeTitle);
                userType.TypeTitleId = type_id;
                return userType;
            }


            //    listUser = new ListUser(userTypes);
            return null;


            //using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            //string quarry = $"select * from tUserType where UserId = {id}";
            //SqlCommand cmd = new SqlCommand(quarry, con);
            //con.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            //UserType userType;

            //User user;

            //if (dr.Read())
            //{


            //  long Id = Convert.ToInt32(dr["Id"]);
            //  long UserId = Convert.ToInt32(dr["UserId"]);
            //  long ParentId = Convert.ToInt32(dr["ParentId"]);
            //  int TypeTitleId = Convert.ToInt32(dr["TypeId"]);
            //  DateTime CreateDate = Convert.ToDateTime(dr["CreateDate"]);


            //  string fisrtName = dr["FirstName"].ToString();


            ////  DateTime ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
            //   userType = new UserType(new User(), ParentId, TypeTitleId, CreateDate);
            //  //UserType userType = new UserType(ParentId, TypeTitleId, CreateDate, ModifyDate);
            //  //userType.Id = Id;
            //  //userType.UserId = UserId;


            // return userType;
            // userTypes.Add(userType);
            // }

            return null;


            // return dr.Read() ? Convert.ToInt64(dr["Id"]) : -1;
        }


        public static void AddUserType(UserType userType)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string quarry = "Insert into tUserType (UserId,ParentId,TypeId, CreateDate,ModifyDate) " +
                            $"Values(IDENT_CURRENT('tUser'), null , null, GETDATE(),null)";


            con.Open();
            SqlCommand cmd = new SqlCommand(quarry, con);
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

        public static void AddFamilyUserType(UserType userType)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());


            string quarry = "Insert into tUserType (UserId,ParentId,TypeId, CreateDate,ModifyDate) " +
                            $"Values(IDENT_CURRENT('tUser'), '{userType.ParentId}' , '{userType.TypeTitleId}', GETDATE(), null)";


            con.Open();
            SqlCommand cmd = new SqlCommand(quarry, con);
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

        public static void UpdateUserType(UserType userType)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = "update  tUserType " +
                           $"Set  TypeId = '{userType.TypeTitleId}', ModifyDate = GETDATE()" +
                           $" where UserId = {userType.User.Id}";


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

        public static void UpdateUserType(User user)
        {
            using SqlConnection con = new SqlConnection(ConnectionDbclass.GetConnectionString());

            string query = "update  tUserType" +
                           $" Set  ModifyDate = GETDATE()" +
                           $" where UserId = {user.Id}";


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
    }
}