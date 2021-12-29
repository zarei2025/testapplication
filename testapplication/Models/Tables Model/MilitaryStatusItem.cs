using System.ComponentModel.DataAnnotations;

namespace testapplication.Models.Tables_Model
{
    public class MilitaryStatusItem:Item
    {
        public int UseCount { get; set; }

        public MilitaryStatusItem(string typeTitle)
        {
            TypeTitle = typeTitle;
        }

        public MilitaryStatusItem(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public void SetUseCount(int count)
        {
            UseCount = count;
        }

        public MilitaryStatusItem()
        {
        }
    }
}

