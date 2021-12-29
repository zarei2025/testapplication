using System.ComponentModel.DataAnnotations;

namespace testapplication.Models.Tables_Model
{
    public class DegreeEducationItem:Item
    {
        public int UseCount { get; set; }

        public DegreeEducationItem(string typeTitle)
        {
            TypeTitle = typeTitle;
        }

        public DegreeEducationItem(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public void SetUseCount(int count)
        {
            UseCount = count;
        }

        public DegreeEducationItem()
        {
        }
    }
}

