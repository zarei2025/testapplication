using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testapplication.Models
{
    public class ItemTable
    {
        public int  Id{ get; set; }
        [Required(ErrorMessage = "عنوان نمیتواند خالی باشد")]
        public string Title { get; set; }
        public string TypeTitle { get; set; }
        public int UseCount { get; set; }

        public ItemTable(string typeTitle)
        {
            TypeTitle = typeTitle;
        }

        public ItemTable(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public void SetUseCount(int count)
        {
            UseCount = count;
        }

        public ItemTable()
        {
        }
    }
}
