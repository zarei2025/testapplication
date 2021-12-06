using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using testapplication.Models;
using testapplication.Models.Session;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace testapplication.Controllers
{
    public class HomeController : Controller
    {
        private static long idUser;
        private static User globalUser;
        private static long idSubUser;
        BaseQuery baseQuery = new BaseQuery();
        private static string titleID;


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {

            if (user.NationalCode == "0000000000")
            {
                return RedirectToAction("Management");
            }
            var userNationalCode = user.NationalCode;
            var userPassword = user.Password;
            if (string.IsNullOrWhiteSpace(userNationalCode) || string.IsNullOrWhiteSpace(userPassword))
            {
                return View(user);
            }

            User user1 = UserDataAccessLayer.GetUserBy(userNationalCode, userPassword);

            if (user1 != null)
            {
                idUser = user1.Id;
                AddCookie(idUser, "checkstring");
                return RedirectToAction("FamilyList");
            }

            ViewBag.login_error = "اظلاعات وارد شده صحیح نمیباشد.";
            return View(user);
        }

        public IActionResult Logintoregister()
        {
            return RedirectToAction("Register");
        }


        [HttpGet]
        public IActionResult FamilyList()
        {
            if (CheckCookie("checkstring"))
            {
                User user = UserDataAccessLayer.GetUserBy(idUser);

                List<UserType> userTypes = UserDataAccessLayer.GetFamily(idUser);

                globalUser = new User(user.NationalCode, user.FirstName, user.LastName);
                ViewBag.User = globalUser;

                return View(userTypes);
            }
            else
            {
                return View("Login");
            }
        }


        [HttpPost]
        public IActionResult FamilyList(List<UserType> userTypes)
        {
            return RedirectToAction("RegisterFamily", userTypes);
        }


        [HttpGet]
        public IActionResult Register()
        {
            Province_Bind();

            User user;

            if (idUser != 0)
            {
                if (CheckCookie("checkstring"))
                {
                    user = UserDataAccessLayer.GetUserBy(idUser);

                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                user = new User();
            }

            List<Item> degreeEducations = UserDataAccessLayer.GetItem("tDegreeEducation");
            List<Item> Provinces = UserDataAccessLayer.GetItem("tProvince");
            List<Item> Religions = UserDataAccessLayer.GetItem("tReligion");
            List<Item> MilitaryStatuses = UserDataAccessLayer.GetItem("tMilitaryStatus");
            //List<Item> Cities = UserDataAccessLayer.GetItem("tCity");

            user.DegreeEducationList = new SelectList(degreeEducations, "Id", "Title");
            user.ReligionList = new SelectList(Religions, "Id", "Title");
            user.ProvinceList = new SelectList(Provinces, "Id", "Title");
            user.MilitaryStatusList = new SelectList(MilitaryStatuses, "Id", "Title");
            //  user.CityList = new SelectList(Cities, "Id", "Title", null, "ParentId");

            // user.CityItemList = Cities;


            return View(user);
        }


        [HttpPost]
        public IActionResult Register(User user)
        {
            Province_Bind();

            var userBirthdatestring = user.birthdatestring;
            var userNationalCode = user.NationalCode;
            var userPassword = user.Password;
            var userFirstName = user.FirstName;
            var userLastName = user.LastName;
            user.BirthDate = Tools.ToGeorgianDateTime(Tools.ToEnglishNumber(userBirthdatestring));
            user.Id = idUser;


            if (string.IsNullOrWhiteSpace(userNationalCode) || string.IsNullOrWhiteSpace(userFirstName) ||
                string.IsNullOrWhiteSpace(userLastName))
            {
                ViewBag.user_empty_error = "فیلد های اجباری را تکمیل کنید.";
                return View(user);
            }

            if (idUser != 0)
            {

                var userId = UserDataAccessLayer.GetUserIdBy(userNationalCode);
                if (userId == -1)
                {
                    UserDataAccessLayer.UpdateUser(user);
                    UserTypeDataAccessLayer.UpdateUserType(user);
                    return RedirectToAction("FamilyList");
                }
                else
                {
                    ViewBag.nationalcode_unique_error = "کد ملی وارد شده تکراری است.";
                    return View(user);
                }
                

            }
            else
            {
                var userId = UserDataAccessLayer.GetUserIdBy(userNationalCode);
                if (userId == -1)
                {
                    UserDataAccessLayer.AddUser(user);
                    UserType userType = new UserType(user);
                    UserTypeDataAccessLayer.AddUserType(userType);
                    return RedirectToAction("SetPassword");
                }
                else
                {
                    ViewBag.nationalcode_unique_error = "کد ملی وارد شده تکراری است.";
                    return View(user);
                }
            }


            /*  else
              {
  
                  if (string.IsNullOrWhiteSpace(userNationalCode) || string.IsNullOrWhiteSpace(userPassword) ||
                      string.IsNullOrWhiteSpace(userFirstName) || string.IsNullOrWhiteSpace(userLastName))
                  {
                      ViewBag.user_empty_error = "فیلد های اجباری را تکمیل کنید.";
                      return View(userType);
                  }
  
                  if (String.IsNullOrWhiteSpace(parentNationalCode))
                  {
                      if (TypeTitleId == 0)
                      {
                          ViewBag.typetitle_empty_nc_error = "اگر سرپرست وجود دارد باید کد ملی آن را وارد کنید.";
                          return View(userType);
                      }
  
                      var userId = UserDataAccessLayer.GetUserIdBy(userNationalCode);
                      if (userId != -1)
                      {
                          UserDataAccessLayer.UpdateUser(userId, userNationalCode, userPassword, userFirstName, userLastName);
                          UserTypeDataAccessLayer.UpdateUserType(null, TypeTitleId, DateTime.Now, DateTime.Now);
                      }
                      else
                      {
                          ViewBag.typetitle_unique_error = "کد ملی وارد شده تکراری است.";
                          return View(userType);
                      }
                  }
                  else
                  {
                      if (TypeTitleId == 0)
                      {
                          ViewBag.typetitle_empty_type_error = "اگر سرپرست وجود دارد باید نوع آن را وارد کنید.";
                          return View(userType);
                      }
  
                      var parent_user_id = UserDataAccessLayer.GetUserIdBy(parentNationalCode);
                      if (parent_user_id == -1)
                      {
                          ViewBag.typetitle_notfound_error = "کدملی وارد شده برای سرپرست در سیستم ثبت نشده است.";
  
                          return View(userType);
                      }
  
                      var userId = UserDataAccessLayer.GetUserIdBy(userNationalCode);
                      if (userId == -1)
                      {
                          UserDataAccessLayer.UpdateUser(userId, userNationalCode, userPassword, userFirstName, userLastName);
                          UserTypeDataAccessLayer.UpdateUserType(parent_user_id, userType.TypeTitleId, DateTime.Now, DateTime.Now);
                      }
                      else
                      {
                          ViewBag.typetitle_unique_error = "کد ملی وارد شده تکراری است.";
                          return View(userType);
                      }
                  }
  
  
                  
              }*/

            return RedirectToAction("FamilyList");
        }

        public IActionResult SetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetPassword(User user)
        {
            user.Id = idUser;
            UserDataAccessLayer.Password(user);
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult RegisterFamily(long id = 0)
        {
            Province_Bind();
            ViewBag.User = globalUser;


            idSubUser = id;
            UserType userType;


            if (id != 0)
            {
                userType = UserTypeDataAccessLayer.GetUserTypeBy(id);
            }
            else
            {
                userType = new UserType();
                User user = new User();
                userType.User = user;
            }

            // User user = new User();
            List<Item> degreeEducations = UserDataAccessLayer.GetItem("tDegreeEducation");
            List<Item> Provinces = UserDataAccessLayer.GetItem("tProvince");
            List<Item> Religions = UserDataAccessLayer.GetItem("tReligion");
            List<Item> MilitaryStatuses = UserDataAccessLayer.GetItem("tMilitaryStatus");
            List<Item> FamilyType = UserDataAccessLayer.GetItem("tFamilyType");

            //List<Item> Cities = UserDataAccessLayer.GetItem("tCity");

            userType.User.DegreeEducationList = new SelectList(degreeEducations, "Id", "Title");
            userType.User.ReligionList = new SelectList(Religions, "Id", "Title");
            userType.User.ProvinceList = new SelectList(Provinces, "Id", "Title");
            userType.User.MilitaryStatusList = new SelectList(MilitaryStatuses, "Id", "Title");
            userType.FamilyTypeList = new SelectList(FamilyType, "Id", "Title");
            //  user.CityList = new SelectList(Cities, "Id", "Title", null, "ParentId");

            // user.CityItemList = Cities;
            //userType.User = user;
            return View(userType);


            //  return View(userType);


            //   long id = userType.Id;

            // Request.Form["select"]


            //Register()
            //long id = userType.Id;
        }

        [HttpPost]
        public IActionResult RegisterFamily(UserType userType)
        {
            Province_Bind();

            userType.ParentId = idUser;
            userType.User.Id = idSubUser;
            userType.User.BirthDate = Tools.ToGeorgianDateTime(Tools.ToEnglishNumber(userType.User.birthdatestring));



            if (idSubUser != 0)
            {
                UserDataAccessLayer.UpdateUser(userType.User);
                UserTypeDataAccessLayer.UpdateUserType(userType);
            }
            else
            {
                UserDataAccessLayer.AddFamilyUser(userType.User);
                UserTypeDataAccessLayer.AddFamilyUserType(userType);
            }


            return RedirectToAction("FamilyList");


            //   long id = userType.Id;

            // Request.Form["select"]


            //Register()
            //long id = userType.Id;
        }

        public IActionResult DeleteFamily(long id = 0)
        {
            if (id != 0)
            {
                UserDataAccessLayer.DeleteUser(id);
            }


            List<UserType> userTypes = UserDataAccessLayer.GetFamily(idUser);

            ViewBag.User = globalUser;
            ViewBag.deletefromfamily = "حذف با موفقت انجام شد.";
            return View("FamilyList", userTypes);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(User user)
        {
            user.Id = idUser;
            string pass = UserDataAccessLayer.GetUserPassBy(user.Id);
            if (ComputeSha256Hash(user.OldPassword).Equals(pass))
            {
                UserDataAccessLayer.Password(user);
                return RedirectToAction("FamilyList");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Management()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Management(UserType userType)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            string cookieString = Request.Cookies["checkstring"];

            if (cookieString == null)
            {
                ViewBag.cookie = "time out";
                return View();
            }
            else
            {
                string DBCheckstring = SessionDataAccessLayer.GetSessionCheckstring(cookieString,15);
                if (DBCheckstring == null)
                {
                    ViewBag.badcookie = "changed cookie";
                    return View();
                }
                else
                {
                }

                return View("Privacy");
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Guest()
        {
            string checkstring = DateTime.UtcNow.Ticks.ToString();

            Session session = new Session(0, checkstring, DateTime.Now);
            SessionDataAccessLayer.AddSession(session);
            return RedirectToAction("Index");
        }

        //public IActionResult TableContent()
        //{
        //    return View("TableAdmin");
        //}

        public IActionResult aaaaVC(string uid = "DegreeEducation")
        {
            titleID = uid;
            return ViewComponent("Tablestwo", new { uid });//it will call Follower.cs InvokeAsync, and pass id to it.
        }

        [HttpGet]
        public IActionResult CreateItem()
        {
            return PartialView("CreateItem", new ItemTable(titleID));
        }
        //[HttpGet]
        //public IActionResult CreateItem(ItemTable item)
        //{
        //    return View();
        //}

        //public JsonResult saveRows([FromBody] List<string> new_title_array)
        //{
        //    List<string> title = new List<string>();
        //    for (int i = 0; i < new_title_array.Count; i++)
        //    {
        //        var replace = new_title_array[i].Replace("\n", "");

        //        title.Add(WebUtility.HtmlDecode(replace).Trim());
        //    }

        //    title = title.Distinct().ToList();
        //    List<string> title_from_database = UserDataAccessLayer.getInfo(titleID);
        //    for (int i = 0; i < title.Count; i++)
        //    {
        //        if (title_from_database.Contains(title[i]) || title[i] == "")
        //        {
        //            ViewBag.Duplicates = "موارد تکراری ثبت نشد.";
        //            title.RemoveAt(i);
        //        }
        //    }

        //    UserDataAccessLayer.updateRows(title, titleID);

        //    return Json(titleID);

        //}

        public bool CheckCookie(string cookieName)
        {
            string cookieString = Request.Cookies[cookieName];

            if (cookieString == null)
            {
                ViewBag.cookie = "time out";
                idUser = 0;
                return false;
            }
            else
            {
                string dbCheckstring = SessionDataAccessLayer.GetSessionCheckstring(cookieString,15);
                if (dbCheckstring == null)
                {
                    ViewBag.badcookie = "changed cookie";
                    idUser = 0;
                    return false;
                }

                SessionDataAccessLayer.UpdateSession(dbCheckstring);
                //cookie
                Response.Cookies.Append(cookieName, dbCheckstring, new CookieOptions

                {
                    Expires = DateTime.Now.AddSeconds(15)
                });
                return true;
            }
        }

        public void AddCookie(long userid,string cookieName)
        {

            string checkstring = DateTime.UtcNow.Ticks.ToString();
            Session session = new Session(userid, checkstring, DateTime.Now);
            SessionDataAccessLayer.AddSession(session);


            //cookie
            Response.Cookies.Append(cookieName, ComputeSha256Hash(checkstring), new CookieOptions

            {
                Expires = DateTime.Now.AddSeconds(15)
            });

        }

        public void Province_Bind()
        {
            DataSet ds = baseQuery.Get_Province();
            List<SelectListItem> provinceList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                provinceList.Add(new SelectListItem
                    { Text = dr["Title"].ToString(), Value = dr["Id"].ToString() });
            }

            ViewBag.Province = provinceList;
        }

        public JsonResult City_Bind(int state_id)
        {
            DataSet ds = baseQuery.Get_City(state_id);
            List<SelectListItem> citylist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                citylist.Add(new SelectListItem { Text = dr["Title"].ToString(), Value = dr["Id"].ToString() });
            }

            return Json(citylist);
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