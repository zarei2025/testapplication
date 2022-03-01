using System.ComponentModel.DataAnnotations;

namespace testapplication.Models.Tables_Model
{
    public class DegreeEducationItem:Item
    {

        public DegreeEducationItem(string typeTitle)
        {
            TypeTitle = typeTitle;
        }

        public DegreeEducationItem(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public DegreeEducationItem()
        {
        }
    }
}

