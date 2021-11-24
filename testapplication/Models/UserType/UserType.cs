using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace testapplication.Models
{
    public class UserType : IEnumerable
    {
        public long Id { get; set; }
      //  public long UserId { get; set; }
        public long? ParentId { get; set; }
        public long? TypeTitleId { get; set; }
        public string TypeTitle { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public User User { get; set; }
        public User ParentUser { get; set; }

        public SelectList FamilyTypeList { get; set; }


        //  public string FamilyTitle { get; set; }

        public UserType(long? typeTitleId, DateTime date, DateTime? modifyDate)
        {
           // ParentId = parentId;
            TypeTitleId = typeTitleId;
            CreateDate = date;
            ModifyDate = modifyDate;
        }

        public UserType(long? typeTitleId, DateTime date)
        {
         //   ParentId = parentId;
            TypeTitleId = typeTitleId;
            CreateDate = date;

        }

        public UserType(User parentuser,User user, string typetitle)
        {
            ParentUser = parentuser;
            User = user;
            TypeTitle = typetitle;

        }

        public UserType()
        {
        }

        public UserType(User user)
        {
            User = user;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}