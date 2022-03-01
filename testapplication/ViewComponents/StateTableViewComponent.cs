using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testapplication.Models;
using testapplication.Models.Tables_Model;

namespace testapplication.ViewComponents
{
    public class StateTableViewComponent : ViewComponent

    {
        //public async Task<IViewComponentResult> InvokeAsync(string id)
        //{
        //    List<string> degree = UserDataAccessLayer.getInfo(id);
        //    return View("_TablesTwo", degree);
        //}

        public IViewComponentResult Invoke(string uid)
        {
            List<CityItem> cityItems= new List<CityItem> { };
            if (uid == "0")
            {
              //  relativeItems = UserDataAccessLayer.getInfo("DegreeEducation");

               // return View("_RelativeTable", relativeItems);
            }
            //cityItems = UserDataAccessLayer.GetStateItems(10);

            return View("_StateTable", cityItems);
        }
    }
}