using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapplication.Models
{
    public class ItemTable
    {
        public int  Id{ get; set; }
        public string Title { get; set; }
        public string TypeTitle { get; set; }

        public ItemTable(string typeTitle)
        {
            TypeTitle = typeTitle;
        }

        public ItemTable(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
