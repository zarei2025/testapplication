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
            List<ItemTable> itemTables;
            if (uid == "0")
            {
                itemTables = UserDataAccessLayer.getInfo("DegreeEducation");

                return View("_TablesTwo", itemTables);
            }
            itemTables = UserDataAccessLayer.getInfo(uid);

            return View("_TablesTwo", itemTables);
        }
    }
}