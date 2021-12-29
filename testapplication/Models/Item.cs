using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testapplication.Models
{
    public class Item
    {
        public int Id { get; set; }
         public int ParentId { get; set; }
        [Required(ErrorMessage = "عنوان نمیتواند خالی باشد")]
        public string Title { get; set; }
        public string TypeTitle { get; set; }

        public Item()
        {
        }

        public Item(int id, string title, int parentId=0)
        {
            Id = id;
            ParentId = parentId;
            Title = title;
        }

        
        public Item(string typeTitle)
        {
            TypeTitle = typeTitle;
        }
    }
}