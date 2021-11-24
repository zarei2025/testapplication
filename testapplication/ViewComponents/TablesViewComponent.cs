using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using testapplication.Models;

namespace testapplication.ViewComponents
{
    public  class TablesViewComponent : ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            List<User> users = UserDataAccessLayer.GetAllUser();


            return View("_Tables", users);
        }
    }
}