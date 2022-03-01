using System.ComponentModel.DataAnnotations;

namespace testapplication.Models.Tables_Model
{
    public class ReligionItem:Item
    {

        public ReligionItem(string typeTitle)
        {
            TypeTitle = typeTitle;
        }

        public ReligionItem(int id, string title)
        {
            Id = id;
            Title = title;
        }

       

        public ReligionItem()
        {
        }
    }
}

