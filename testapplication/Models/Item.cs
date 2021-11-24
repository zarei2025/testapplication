using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapplication.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        public string Title { get; set; }

        public Item(int id, string title, int parentId = 0)
        {
            Id = id;
            ParentId = parentId;
            Title = title;
        }
    }
}