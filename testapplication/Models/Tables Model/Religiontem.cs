using System.ComponentModel.DataAnnotations;

namespace testapplication.Models.Tables_Model
{
    public class ReligionItem:Item
    {
        public int UseCount { get; set; }

        public ReligionItem(string typeTitle)
        {
            TypeTitle = typeTitle;
        }

        public ReligionItem(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public void SetUseCount(int count)
        {
            UseCount = count;
        }

        public ReligionItem()
        {
        }
    }
}

