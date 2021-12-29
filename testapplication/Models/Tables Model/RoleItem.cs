using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapplication.Models.Tables_Model
{
    public class RoleItem:Item
    {
        public int UseCount { get; set; }


        public RoleItem(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public void SetUseCount(int count)
        {
            UseCount = count;
        }
    }
}
