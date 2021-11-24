using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapplication.Models.Session
{
    public class Session
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string CheckString { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UdateTime { get; set; }


        public Session(long userId, string checkString, DateTime createDate)
        {
            UserId = userId;
            CheckString = checkString;
            CreateDate = createDate;
            UdateTime = createDate;
        }

    }
}
