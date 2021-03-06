using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testapplication.Models;
using testapplication.Models.Tables_Model;

namespace testapplication.ViewComponents
{
    public class UsersTableViewComponent : ViewComponent

    {
        //public async Task<IViewComponentResult> InvokeAsync(string id)
        //{
        //    List<string> degree = UserDataAccessLayer.getInfo(id);
        //    return View("_TablesTwo", degree);
        //}

        public IViewComponentResult Invoke(string uid)
        {
            List<UsersItem> usersItems;
            if (uid == "0")
            {
              //  relativeItems = UserDataAccessLayer.getInfo("DegreeEducation");

               // return View("_RelativeTable", relativeItems);
            }
            usersItems = UserDataAccessLayer.GetUsersItems(uid);

            return View("_UsersTable", usersItems);
        }
    }
}