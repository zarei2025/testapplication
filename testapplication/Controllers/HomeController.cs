using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using testapplication.Models;
using testapplication.Models.Session;
using System.Collections.Generic;
using System.Data;
using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.Rendering;
using testapplication.Models.Tables_Model;




namespace testapplication.Controllers
{
    public class HomeController : Controller
    {
        private static long idUser;
        private static long idUserItem;
        private static User globalUser;
        private static long idSubUser;
        BaseQuery baseQuery = new BaseQuery();
        private static string titleID;


        [HttpGet]
        public IActionResult Login()
        {
            if (Request.Cookies["checkstring"] != null)
            {
                //Response.Cookies.["checkstring"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Delete("checkstring");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            //if (user.NationalCode == "0000000000")
            //{
            //    return RedirectToAction("Management");
            //}

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
                RoleItem roleItem = UserDataAccessLayer.getRole(userNationalCode);
                if (roleItem.Title.Equals("admin"))
                {
                    AddCookie(idUser, "checkstring");
                    return RedirectToAction("Management");
                }
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
                    if (idUserItem !=0)
                    {
                        user = UserDataAccessLayer.GetUserBy(idUserItem);
                        idUserItem = 0;
                    }
                    else
                    {
                        user = UserDataAccessLayer.GetUserBy(idUser);

                    }
                    //     List<Item> Cities = UserDataAccessLayer.GetItemcity(user.Province);
                    //    user.CityList = new SelectList(Cities, "Id", "Title");
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

            FillDropDownList(user);
            
            //  user.CityList = new SelectList(Cities, "Id", "Title", null, "ParentId");

            // user.CityItemList = Cities;


            return View(user);
        }

        private void FillDropDownList(User user)
        {
            List<Item> degreeEducations = UserDataAccessLayer.GetItem("tDegreeEducation");
            List<Item> Provinces = UserDataAccessLayer.GetItem("tProvince");
            List<Item> Religions = UserDataAccessLayer.GetItem("tReligion");
            List<Item> MilitaryStatuses = UserDataAccessLayer.GetItem("tMilitaryStatus");
            //List<Item> Cities = UserDataAccessLayer.GetItem("tCity");

            user.DegreeEducationList = new SelectList(degreeEducations, "Id", "Title");
            user.ReligionList = new SelectList(Religions, "Id", "Title");
            user.ProvinceList = new SelectList(Provinces, "Id", "Title");
            user.MilitaryStatusList = new SelectList(MilitaryStatuses, "Id", "Title");
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
        


            if (string.IsNullOrWhiteSpace(userNationalCode) || string.IsNullOrWhiteSpace(userFirstName) ||
                string.IsNullOrWhiteSpace(userLastName))
            {
                ViewBag.user_empty_error = "فیلد های اجباری را تکمیل کنید.";
                FillDropDownList(user);
                return View(user);
            }

            if (user.Id != 0)
            {
                var userId = UserDataAccessLayer.GetUserIdBy(userNationalCode);
                if (userId == user.Id)
                {
                    UserDataAccessLayer.UpdateUser(user);
                    UserTypeDataAccessLayer.UpdateUserType(user);
                    return RedirectToAction("FamilyList");
                }
                else
                {
                    ViewBag.nationalcode_unique_error = "کد ملی وارد شده تکراری است.";
                    FillDropDownList(user);
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
                    FillDropDownList(user);
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


            idSubUser = id;
            UserType userType;


            if (id != 0)
            {
                userType = UserTypeDataAccessLayer.GetUserTypeBy(id);
                ViewBag.User = userType.User;

            }
            else
            {
                userType = new UserType();
                User user = new User();
                userType.User = user;
            }

            FillDropDownList(userType);
            // User user = new User();
           
            //userType.User = user;
            return View(userType);


            //  return View(userType);


            //   long id = userType.Id;

            // Request.Form["select"]


            //Register()
            //long id = userType.Id;
        }

        private void FillDropDownList(UserType userType)
        {
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
            if (CheckCookie("checkstring"))
            {
                User user = UserDataAccessLayer.GetUserBy(idUser);

            //    List<UserType> userTypes = UserDataAccessLayer.GetFamily(idUser);

                globalUser = new User(user.NationalCode, user.FirstName, user.LastName);
                ViewBag.AdminUser = user;

                return View(user);
            }
            else
            {
                return View("Login");
            }
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
                string DBCheckstring = SessionDataAccessLayer.GetSessionCheckstring(cookieString, 15);
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

        public IActionResult SelectTable(string uid = "DegreeEducation")
        {
            titleID = uid;
            switch (uid)
            {
                case "FamilyType":
                    return ViewComponent("RelativeTable", new { uid }); //it will call Follower.cs InvokeAsync, and pass id to it.
                case "DegreeEducation":
                    return ViewComponent("DegreeEducationTable", new { uid }); //it will call Follower.cs InvokeAsync, and pass id to it.
                case "Religion":
                    return ViewComponent("ReligionTable", new { uid }); //it will call Follower.cs InvokeAsync, and pass id to it.
                case "MilitaryStatus":
                    return ViewComponent("MilitaryStatusTable", new { uid }); //it will call Follower.cs InvokeAsync, and pass id to it.
                case "Province":
                    Province_Bind2();
                    return ViewComponent("StateTable", new { uid }); //it will call Follower.cs InvokeAsync, and pass id to it.
                case "User":
                    return ViewComponent("UsersTable", new { uid }); //it will call Follower.cs InvokeAsync, and pass id to it.



            }

            return null;
            // return ViewComponent("Tablestwo", new { uid }); //it will call Follower.cs InvokeAsync, and pass id to it.
        }
        
        [HttpGet]
        public IActionResult CreateItem()
        {
            return PartialView("CreateItem", new Item(titleID));
           
           // return PartialView("CreateItem", new ItemTable(titleID));
        }

        [HttpPost]
        public JsonResult CreateItem(Item item)
        {
            item.TypeTitle = titleID;
            List<string> title_from_database = UserDataAccessLayer.getItemTitle(titleID);

            if (title_from_database.Contains(item.Title))
            {
                return new JsonResult(null);
            }


            UserDataAccessLayer.InsertItem(item);
            return new JsonResult(titleID);
        }

        [HttpGet]
        public IActionResult EditItem(int id)
        {
            Item item = UserDataAccessLayer.getItem(titleID,id);
            return PartialView("EditItem", item);
        }

        [HttpPost]
        public JsonResult EditItem(Item item)
        {
            item.TypeTitle = titleID;
            List<string> title_from_database = UserDataAccessLayer.getItemTitle(titleID);

            if (title_from_database.Contains(item.Title))
            {
              //  ViewBag.Duplicates2 = "موارد تکراری ثبت نشد.";
                return new JsonResult(null);
            }


            UserDataAccessLayer.UpdateItem(item);
            return new JsonResult(titleID);
        }
        public IActionResult  DeleteItem(int id)
        {
            UserDataAccessLayer.UpdateIsDeletedItem(id,titleID,true);
            switch (titleID)
            {
                case "FamilyType":
                    return ViewComponent("RelativeTable", new { titleID }); //it will call Follower.cs InvokeAsync, and pass id to it.
                case "DegreeEducation":
                    return ViewComponent("DegreeEducationTable", new { titleID }); //it will call Follower.cs InvokeAsync, and pass id to it.
                case "Religion":
                    return ViewComponent("ReligionTable", new { titleID }); //it will call Follower.cs InvokeAsync, and pass id to it.
                case "MilitaryStatus":
                    return ViewComponent("MilitaryStatusTable", new { titleID }); //it will call Follower.cs InvokeAsync, and pass id to it.
                case "Province":
                    Province_Bind2();
                    return ViewComponent("StateTable", new { titleID }); //it will call Follower.cs InvokeAsync, and pass id to it.
                case "User":
                    return ViewComponent("UsersTable", new { titleID });


            }

            return null;
        }
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
                string dbCheckstring = SessionDataAccessLayer.GetSessionCheckstring(cookieString, 120);
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
                    Expires = DateTime.Now.AddMinutes(120)
                });
                return true;
            }
        }

        public void AddCookie(long userid, string cookieName)
        {
            string checkstring = DateTime.UtcNow.Ticks.ToString();
            Session session = new Session(userid, checkstring, DateTime.Now);
            SessionDataAccessLayer.AddSession(session);

            //cookie
            Response.Cookies.Append(cookieName, ComputeSha256Hash(checkstring), new CookieOptions

            {
                Expires = DateTime.Now.AddMinutes(2)
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
        public void Province_Bind2()
        {
            DataSet ds = baseQuery.Get_Province();
            List<SelectListItem> provinceList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                provinceList.Add(new SelectListItem
                    { Text = dr["Title"].ToString(), Value = dr["Id"].ToString() });
            }

            ViewBag.Province2 = provinceList;
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


      
        
        public IActionResult RegisterUser(int id)
        {
            idUserItem = id;
     
            //    User user = UserDataAccessLayer.GetUserBy(id);
            return RedirectToAction("Register");
        }
    }
}