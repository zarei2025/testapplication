using System.ComponentModel.DataAnnotations;

namespace testapplication.Models.Tables_Model
{
    public class CityItem:Item
    {

        public int UseCount { get; set; }


        public CityItem(string typeTitle)
        {
            TypeTitle = typeTitle;
        }

        public CityItem(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public void SetUseCount(int count)
        {
            UseCount = count;
        }

        public CityItem()
        {
        }

    }
}
