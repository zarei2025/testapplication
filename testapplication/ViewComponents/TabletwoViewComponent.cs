using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testapplication.Models;

namespace testapplication.ViewComponents
{
    public class TablestwoViewComponent : ViewComponent

    {
        //public async Task<IViewComponentResult> InvokeAsync(string id)
        //{
        //    List<string> degree = UserDataAccessLayer.getInfo(id);
        //    return View("_TablesTwo", degree);
        //}

        public IViewComponentResult Invoke(string uid)
        {
            List<string> degree;
            if (uid == "0")
            {
                degree = UserDataAccessLayer.getInfo("DegreeEducation");

                return View("_TablesTwo", degree);
            }
            degree = UserDataAccessLayer.getInfo(uid);

            return View("_TablesTwo", degree);
        }
    }
}