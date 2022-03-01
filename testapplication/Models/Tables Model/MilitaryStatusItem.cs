using System.ComponentModel.DataAnnotations;

namespace testapplication.Models.Tables_Model
{
    public class MilitaryStatusItem:Item
    {

        public MilitaryStatusItem(string typeTitle)
        {
            TypeTitle = typeTitle;
        }

        public MilitaryStatusItem(int id, string title)
        {
            Id = id;
            Title = title;
        }


        public MilitaryStatusItem()
        {
        }
    }
}

