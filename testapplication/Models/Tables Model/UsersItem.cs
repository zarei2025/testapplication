using System.ComponentModel.DataAnnotations;

namespace testapplication.Models.Tables_Model
{
    public class UsersItem:Item
    {
        public string NationalCode { get; set; }
        public string FatherName { get; set; }
        public string RoleTitle { get; set; }
        public int FamilyInsertedCount { get; set; }



        public UsersItem(int id, string title,string nationalCode, string fatherName, string roleTitle, int familyInsertedCount, bool isDeleted)
        {
            Id = id;
            Title = title;
            NationalCode = nationalCode;
            FatherName = fatherName;
            RoleTitle = roleTitle;
            FamilyInsertedCount = familyInsertedCount;
            IsDeleted = isDeleted;
        }

    }
}

